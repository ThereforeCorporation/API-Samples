using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Therefore.WebAPI.Exceptions;

namespace Therefore.WebAPI
{
    public class WebAPIClientPlatformCode
    {
        private static readonly string TenantNameHttpHeaderName = "TenantName";
        private static readonly string TimezoneIANA_HeaderName = "The-Timezone-IANA";
        private static readonly string ClientTypeHttpHeaderName = "The-Client-Type";
        private static string AcceptLanguageHttpHeaderName = "Accept-Language";
        private static string CredentialsCodePageHttpHeaderName = "Therefore-Auth-Codepage";
        private static readonly int ClientType = 41; //TWCLIENT_WORKFLOWDLL
        private static string CodePageNumberForUTF8 = "65001"; //code page # for UTF8 charset

        public enum KeyType { password, defaultToken, bearerToken };

        /// <summary>
        /// Executes request and returns response from the server by using the user name/key.
        /// </summary>
        /// <remarks>If userName is null or empty string the name/token from ICredentialsManager will be used. Otherwise given userName/key will be used.</remarks>
        /// <returns></returns>
        public static async Task<TResp> SendRequestRaw<TReq, TResp>(string methodUrl, TReq requestData, string userName, string key, KeyType keyType, string tenant, string language, TimeSpan timeout, string clientTimezoneNameIANA)
            where TReq : class
            where TResp : class
        {
            Debug.WriteLine(string.Format("Started SendRequestRaw(): {0}", requestData.GetType().Name));

            string operationName = getOperationName(requestData.GetType().Name);

            using (System.Net.Http.HttpClient client = new System.Net.Http.HttpClient())
            {
                //1. Configure HTTP request
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpRequestMessage request = new System.Net.Http.HttpRequestMessage(System.Net.Http.HttpMethod.Post,
                    string.Format("{0}/{1}", methodUrl, operationName));

                try
                {
                    JsonSerializerSettings serializerSettings = new JsonSerializerSettings
                    {
                        DateFormatHandling = DateFormatHandling.MicrosoftDateFormat,
                        DateTimeZoneHandling = DateTimeZoneHandling.Utc

                    };

                    serializerSettings.Converters.Add(new ByteArrayConverter());

                    //2. Serialize request object into REST
                    string requestContent = JsonConvert.SerializeObject(requestData, serializerSettings);
                    request.Content = new StringContent(requestContent, Encoding.UTF8, "application/json");

                    //3. Set authorization header
                    if (keyType == KeyType.bearerToken)
                        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", key);
                    else
                    {
                        request.Headers.Authorization = new AuthenticationHeaderValue(
                          "Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", userName, key))));
                    }

                    //Add tenant name to HTTP header if needed
                    if (tenant.Length > 0)
                        request.Headers.Add(TenantNameHttpHeaderName, tenant);

                    //Add client timezone
                    request.Headers.Add(TimezoneIANA_HeaderName, clientTimezoneNameIANA);

                    //set token header
                    if (keyType == KeyType.defaultToken)
                        request.Headers.Add(TokenBasedCredentials.UseTokenHttpHeaderName, TokenBasedCredentials.UseTokenHttpHeaderValue);

                    if (language.Length > 0)
                        request.Headers.Add(AcceptLanguageHttpHeaderName, language);

                    request.Headers.Add(CredentialsCodePageHttpHeaderName, CodePageNumberForUTF8);

                    //Add client type to HTTP header
                    request.Headers.Add(ClientTypeHttpHeaderName, ClientType.ToString());

                    //Set Timeout for request
                    client.Timeout = timeout;

                    //4. Send request to the server (freeing the current thread)
                    HttpResponseMessage response = await client.SendAsync(request);

                    //5. Throws an exception if not succeed.
                    if (!response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        throw new HttpStatusCodeException((int)response.StatusCode, response.ReasonPhrase, responseContent);
                    }

                    if (typeof(TResp) == typeof(byte[]))
                    {
                        //6. Read response content as a stream.
                        object responseContent = await response.Content.ReadAsByteArrayAsync();
                        return (TResp)responseContent;
                    }
                    else
                    {
                        //6. Read response content and deserialize it.
                        string responseContent = await response.Content.ReadAsStringAsync();
                        object responseObject = JsonConvert.DeserializeObject(responseContent, typeof(TResp), serializerSettings);
                        return (TResp)responseObject;
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Exception occured in SendRequestRaw(). " + e.Message);
                    throw;
                }
                finally
                {
                    Debug.WriteLine(string.Format("Finished SendRequestRaw(): {0}", requestData.GetType().Name));
                }
            }
        }

        /// <summary>
        /// Takes operation name from the request parameters type name. 
        /// Example: GetCategoriesTreeParams -> GetCategoriesTree
        /// </summary>
        /// <param name="requestParamsTypeName">Type name of operation parameters.</param>
        /// <returns>Operation name.</returns>
        private static string getOperationName(string requestParamsTypeName)
        {
            if (requestParamsTypeName == "QuerySpecificationParams")
                return "GetQuerySpecification";
            else if (requestParamsTypeName == "MoveUserLicenseRequest")
                return "MoveUserLicense";
            else if (requestParamsTypeName == "SignOutRequest")
                return "SignOut";
            else
            {
                int length = requestParamsTypeName.Length - "Params".Length;
                return requestParamsTypeName.Substring(0, length);
            }
        }
    }
}
