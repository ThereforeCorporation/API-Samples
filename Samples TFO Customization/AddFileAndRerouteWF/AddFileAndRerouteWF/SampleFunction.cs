using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Therefore.CallAzureFunction;
using Therefore.WebAPI;
using Therefore.WebAPI.Exceptions;
using System.Collections.Generic;

namespace AddFileAndRerouteWF
{
    public static class SampleFunction
    {
        [FunctionName("SampleFunction")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/SampleFunction")] HttpRequest req,
            ILogger log)
        {
            string errMsg = "";       // error message that will be returned to Therefore for logging
            Exception logEx = null;   // exception details for logging
            bool routingDone = false; // false: WF instance will be routed to the next task.
                                      // true: WF instance will not be routed because routing was done by WebAPI call
            try
            {
                // read parameters passed by Therefore
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                TheReqParams reqParams = TheReqParams.Deserialize(requestBody);
                if (reqParams == null || reqParams.TheInstanceNo <= 0 || reqParams.TheTokenNo <= 0)
                    return new BadRequestObjectResult("Mandatory parameter not set"); // function was not called by Therefore, return HTTP error 400
                reqParams.LogWFInfo(log); // log workflow information now, in case the function crashes later

                // load custom settings from task configuration
                CustomSettings mySettings = CustomSettings.Deserialize(reqParams.TheSettings);

                // configuration
                TheConfig config = TheConfig.Instance;
                config.WebAPIBaseUrl = reqParams.TheWebAPIUrl;
                config.Tenant = reqParams.TheTenant;

                // Web API connection
                WebApiClient client;
                if (!String.IsNullOrEmpty(config.UserName) && !String.IsNullOrEmpty(config.Password)) // specify a user name and password if the permissions from the accessToken would not be sufficient
                    // connection with user name and password/token:
                    client = new WebApiClient(config.UserName, config.Password, config.IsToken, config.WebAPIUrl, config.Tenant, config.Language, config.RequestTimeout, config.ClientTimezoneIANA);
                else
                    // connection with JWT Bearer token 'accessToken'
                    client = new WebApiClient(reqParams.TheAccessToken, config.WebAPIUrl, config.Tenant, config.Language, config.RequestTimeout, config.ClientTimezoneIANA);
                WebApiCommon webApiCommon = new WebApiCommon(client, reqParams.TheInstanceNo, reqParams.TheTokenNo);

                int docNo = reqParams.TheDocNo;

                // retrieve index data
                GetDocumentIndexDataResponse indexData = webApiCommon.GetIndexData(docNo);
                WSIndexDataItem found = Array.Find(indexData.IndexData.IndexDataItems, f =>
                        f.StringIndexData != null && String.Compare(f.StringIndexData.FieldName, "customer_name", true) == 0); //TODO: configure this according to your system
                string customerName = found?.StringIndexData.DataValue;

                if (customerName != null)
                {
                    // call external service
                    if (!IsExtValidationDone(customerName, mySettings.UserInfo))
                    {
                        // customer has not been validated yet.
                        // stop here an let Therefore retry the call later
                        errMsg = "Customer was not yet validated."; //'errMsg' will be treated as an optional information here and not as an error.
                        TheRespParams respWaitParams = new TheRespParams(30, errMsg); // approx. 30 minutes
                        return new OkObjectResult(respWaitParams.Serialize());
                    }

                    // save index data as text file
                    WSStreamInfoWithData streamData = new WSStreamInfoWithData();
                    streamData.FileData = GenerateFileFromIndexData(indexData);
                    streamData.FileName = Guid.NewGuid().ToString("D") + ".txt";
                    AddStreamsToDocumentParams addStreamParams = new AddStreamsToDocumentParams();
                    addStreamParams.DocNo = docNo;
                    addStreamParams.StreamsToUpload = new WSStreamInfoWithData[] { streamData };
                    addStreamParams.ConversionOptions = new WSConversionOptions();
                    addStreamParams.CheckInComments = "Changed by automatic workflow task.";
                    webApiCommon.AddStreamsToDoc(addStreamParams);
                }
                else
                {
                    // reroute the workflow instance because 'customer name' is missing
                    int taskNo = mySettings.TaskNo; // task number from 'custom settings' in task configuration
                    webApiCommon.RouteWFInstance(taskNo);

                    // notify Therefore that routing was done, so it does not route again
                    routingDone = true;
                }
            }
            catch (AggregateException ae)
            {
                ae.Handle((ex) =>
                {
                    logEx = ex;
                    if (ex is HttpStatusCodeException)
                    {
                        WebAPIException webAPIEx;
                        if (WebAPIException.TryDecodeWebAPIException((HttpStatusCodeException)ex, out webAPIEx))
                        {
                            errMsg = webAPIEx.Message;
                            return true;
                        }
                    }
                    errMsg = ex.ToString();
                    return true;
                });
            }
            catch (Exception ex)
            {
                logEx = ex;
                errMsg = ex.ToString(); // let Therefore know that an error has occurred
            }

            if (!String.IsNullOrWhiteSpace(errMsg) || logEx != null)
                log.LogError(logEx, errMsg); // log the error so it can be viewed in the Azure Portal

            TheRespParams respParams = new TheRespParams(errMsg, routingDone);
            return new OkObjectResult(respParams.Serialize());
        }

        private static byte[] GenerateFileFromIndexData(GetDocumentIndexDataResponse indexData)
        {
            // save index data as text file
            List<string> values = new List<string>();
            foreach (WSIndexDataItem item in indexData.IndexData.IndexDataItems)
            {
                // only extract integer and string values:
                if (item.StringIndexData != null)
                    values.Add(item.StringIndexData.FieldName + ": " + item.StringIndexData.DataValue);
                else if (item.IntIndexData != null)
                    values.Add(item.IntIndexData.FieldName + ": " + item.IntIndexData.DataValue.ToString());
            }
            MemoryStream memStream = new MemoryStream();
            StreamWriter streamWriter = new StreamWriter(memStream);
            foreach (string value in values)
            {
                streamWriter.WriteLine(value);
            }
            streamWriter.Close();
            ArraySegment<byte> buffer = new ArraySegment<byte>();
            if (!memStream.TryGetBuffer(out buffer))
                throw new Exception("Could not copy buffer from memory stream.");
            return buffer.ToArray();
        }

        private static bool IsExtValidationDone(string customerName, string userInfo)
        {
            // TODO: implement external call here
            Random rnd = new Random(Guid.NewGuid().GetHashCode());
            return rnd.Next(0, 2) == 0;
        }
    }
}
