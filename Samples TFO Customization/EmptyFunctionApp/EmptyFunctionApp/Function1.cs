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

namespace EmptyFunctionApp
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "v1/Function1")] HttpRequest req, ILogger log)
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

                // Add your code here
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
    }
}
