using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace SDKSamples.ESignature
{
    [ApiController]
    [Route("[controller]")]
    public class CustomSigningController : ControllerBase
    {
        private readonly ILogger<CustomSigningController> _logger;
        private readonly IOptions<EnvironmentVariables> _options;//contains the Web API URL from the appsettings.json file

        private static X509Certificate2 _validationCertificate = new X509Certificate2(); //used for token validation to ensure the correct Therefore Server is calling the service        
        private static System.Net.Http.HttpClient _client = new System.Net.Http.HttpClient(); //used for retrieving the public key for token validation and for forwarding push notifications

        public CustomSigningController(ILogger<CustomSigningController> logger, IOptions<EnvironmentVariables> envVars)
        {
            _logger = logger;
            _options = envVars;
        }

        // the Therefore™ Server sends a signed token with every call to prevent the service to be called from a different source
        // the token is validated here. this step is optional but highly recommended
        private ActionResult ValidateToken()
        {
            string token = Request.Headers["validationToken"];
            JwtSecurityToken loadedToken = new JwtSecurityToken(token);
            lock (_validationCertificate)
            {
                if (_validationCertificate.Handle == IntPtr.Zero)
                {
                    try
                    {
                        LoadValidationCertificate();
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, new TheError("Unable to retrieve public key from the Therefore server.\r\nMake sure the Web API URL is configured correctly and that the Web API is reachable.", TheErrorSource.Service, ex.StackTrace));
                    }
                }
            }
            try
            {
                //token validation
                TokenValidationParameters validationParameters = new TokenValidationParameters();
                validationParameters.IssuerSigningKey = new X509SecurityKey(_validationCertificate);

                validationParameters.ValidAudience = "b00752bc-bd9b-4501-ba69-5578a03adceb"; // the Therefore™ Server audience
                validationParameters.ValidIssuer = loadedToken.Issuer;

                SecurityToken validatedToken;

                JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(token, validationParameters, out validatedToken);
            }
            catch (SecurityTokenException ex)
            {
                _logger.LogInformation($"Invalid token from {Request.HttpContext.Connection.RemoteIpAddress.ToString()}.");
                return StatusCode(StatusCodes.Status400BadRequest, new TheError("Token invalid.", TheErrorSource.Service, ex.StackTrace));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new TheError("An error occurred during token validation.", TheErrorSource.Service, ex.StackTrace));
            }
            return null;
        }

        // load the public key for validating that only the correct Therefore™ Server is calling the service to prevent abuse
        private void LoadValidationCertificate()
        {
            string tenant = Request.Headers["tenantName"]; //the Therefore tenant that sent the request to the service
            HttpRequestMessage req = new HttpRequestMessage();
            GetSettingParams parameters = new GetSettingParams() { SettingKey = 3108 }; //this setting is for loading the public key from Therefore

            req.Method = HttpMethod.Post;
            req.RequestUri = new Uri(new Uri(_options.Value.WebAPIURL), "GetPublicSettingString"); // the Therefore Web API method GetPublicSettingString does not require authentication and only returns specific publicly available settings
            req.Headers.Add("TenantName", tenant);
            
            string jsonMsg = JsonConvert.SerializeObject(parameters);
            req.Content = new StringContent(jsonMsg, System.Text.Encoding.UTF8, "application/json");

            Task<HttpResponseMessage> response = _client.SendAsync(req);
            response.Wait();
            if (!response.Result.IsSuccessStatusCode)
                throw new Exception($"Retrieving the public key failed with HTTP status code {response.Result.StatusCode}.");
            Task<string> content = response.Result.Content.ReadAsStringAsync();
            GetSettingResponse setting = (GetSettingResponse)JsonConvert.DeserializeObject(content.Result, typeof(GetSettingResponse));

            _validationCertificate = new X509Certificate2(Convert.FromBase64String(setting.SettingValue));
        }

        // GET connection is called when pressing the "Test Connection" button in the provider configuration in Designer
        [HttpGet("Connection")]
        public ActionResult TestConnection()
        {
            try
            {
                string username = Request.Headers["username"]; //can be empty when only an API key is needed
                string password = Request.Headers["password"];
                string providerURL = Request.Headers["providerUrl"];
                if (password == "" || providerURL == "")
                    return StatusCode(StatusCodes.Status400BadRequest, new TheError("Login information missing", TheErrorSource.Service));
                ActionResult errRes = ValidateToken();
                if (errRes != null)
                    return errRes;

                return Ok(new ConnectionResult()); //for testing purposes always return true
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new TheError(ex.Message, TheErrorSource.Provider, ex.StackTrace));
            }
        }

        // GET returns the settings for configuration in the Workflow and Content Connector
        // lcid will provider the language used by the Designer calling the service. This allows to return values language specific
        [HttpGet("")]
        public ActionResult GetSettings([FromQuery]string lcid)
        {
            try
            {
                string username = Request.Headers["username"]; //can be empty when only an API key is needed
                string password = Request.Headers["password"];
                string providerURL = Request.Headers["providerUrl"];
                if (password == "" || providerURL == "")
                    return StatusCode(StatusCodes.Status400BadRequest, new TheError("Login information missing", TheErrorSource.Service));
                ActionResult errRes = ValidateToken();
                if (errRes != null)
                    return errRes;
                uint nLcid;
                if (!uint.TryParse(lcid, out nLcid))
                    throw new Exception("Invalid LCID specified.");
                ProviderInfo jsonReply = new ProviderInfo();
                FakeProvider provider = new FakeProvider();

                //load templates from provider and add them to the response
                List<Template> templates = provider.GetTemplates();
                foreach (Template t in templates)
                    jsonReply.Templates.Add(t.TemplateID, t.Name);

                jsonReply.SignerProperties.Add(new SettingProperty { Id = "name", Display = "Name", Mandatory = true });
                jsonReply.SignerProperties.Add(new SettingProperty { Id = "email", Display = "Email", Mandatory = true });
                jsonReply.SignerProperties.Add(new SettingProperty { Id = "phone", Display = "Phone", Mandatory = true });

                jsonReply.SupportedWorkflowFeatures.Subject = true;
                jsonReply.SupportedWorkflowFeatures.Context = true;
                jsonReply.SupportedWorkflowFeatures.ForcePDFConversion = false;
                jsonReply.SupportedWorkflowFeatures.SigningOrder = true;
                jsonReply.SupportedWorkflowFeatures.TemplateFields = true;
                jsonReply.SupportedWorkflowFeatures.PredefinedTemplateFields = true;
                
                return Ok(jsonReply);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new TheError(ex.Message, TheErrorSource.Provider, ex.StackTrace));
            }
        }

        // GET templates returns a list of all templates
        // called when selecting a provider configuration in a "Send for Signing" Workflow Task or when an already configured task is opened
        [HttpGet("Templates")]
        public ActionResult GetTemplates()
        {
            try
            {
                string username = Request.Headers["username"]; //can be empty when only an API key is needed
                string password = Request.Headers["password"];
                string providerURL = Request.Headers["providerUrl"];
                if (password == "" || providerURL == "")
                    return StatusCode(StatusCodes.Status400BadRequest, new TheError("Login information missing", TheErrorSource.Service));
                ActionResult errRes = ValidateToken();
                if (errRes != null)
                    return errRes;
                Dictionary<string, string> jsonReply = new Dictionary<string, string>();
                FakeProvider provider = new FakeProvider();

                //load templates from provider and add them to the response
                List<Template> templates = provider.GetTemplates();
                foreach (Template t in templates)
                    jsonReply.Add(t.TemplateID, t.Name);
                return Ok(jsonReply);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new TheError(ex.Message, TheErrorSource.Provider, ex.StackTrace));
            }
        }

        // GET templates with templateid returns template fields
        // called when selecting a template in the settings of the "Send for Signing" Workflow Task or when an already configured task with a template configured is opened
        // templateid will be returned by GetTemplates before
        [HttpGet("Templates/{templateid}")]
        public ActionResult GetTemplateProperties(string templateid)
        {
            try
            {
                string username = Request.Headers["username"]; //can be empty when only an API key is needed
                string password = Request.Headers["password"];
                string providerURL = Request.Headers["providerUrl"];
                if (password == "" || providerURL == "")
                    return StatusCode(StatusCodes.Status400BadRequest, new TheError("Login information missing", TheErrorSource.Service));
                ActionResult errRes = ValidateToken();
                if (errRes != null)
                    return errRes;
                FakeProvider provider = new FakeProvider();

                //load template fields from provider and add them to the response
                TemplateProperties jsonReply = new TemplateProperties();
                jsonReply.Fields = provider.GetTemplateFields(templateid);                
                
                return Ok(jsonReply);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new TheError(ex.Message, TheErrorSource.Provider, ex.StackTrace));
            }
        }

        // POST documents will send the document to the provider
        // called from Workflow engine and Viewer
        // when called from Viewer, SigningInformation.Manual is set to true, otherwise it's set to false
        [HttpPost("Documents")]
        public ActionResult UploadDocument([FromBody] SigningInformation signingInformation)
        {
            try
            {
                string username = Request.Headers["username"]; //can be empty when only an API key is needed
                string password = Request.Headers["password"];
                string providerURL = Request.Headers["providerUrl"];
                if (password == "" || providerURL == "")
                    return StatusCode(StatusCodes.Status400BadRequest, new TheError("Login information missing", TheErrorSource.Service));
                ActionResult errRes = ValidateToken();
                if (errRes != null)
                    return errRes;
                FakeProvider provider = new FakeProvider();
                string documentid = provider.NewDocument(signingInformation.FilesToSign[0].FileBase64, signingInformation.FilesToSign[0].OriginalName, signingInformation.Context);
                UploadDocumentResponse jsonReply = new UploadDocumentResponse(documentid);
                if(signingInformation.Manual)//URL only needed in manual mode
                    jsonReply.URL = new URLResponse { ReturnURL = "http://localhost:5000/Custom", ViewURL = "http://localhost:5000/Custom" };//modify URLs - ReturnURL is for automatically closing the browser window, ViewURL          

                return Ok(jsonReply);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new TheError(ex.Message, TheErrorSource.Provider, ex.StackTrace));
            }
        }

        // GET documents returns a list of signed and rejected documents
        // called from content connector when polling for changes
        // lastcheck contains a timestamp when this method was called the last time
        [HttpGet("Documents")]
        public ActionResult GetDocuments([FromQuery]string lastcheck)
        {
            try
            {
                string username = Request.Headers["username"]; //can be empty when only an API key is needed
                string password = Request.Headers["password"];
                string providerURL = Request.Headers["providerUrl"];
                if (password == "" || providerURL == "")
                    return StatusCode(StatusCodes.Status400BadRequest, new TheError("Login information missing", TheErrorSource.Service));
                ActionResult errRes = ValidateToken();
                if (errRes != null)
                    return errRes;
                FakeProvider provider = new FakeProvider();
                GetDocumentsResponse jsonReply = new GetDocumentsResponse();

                List<Document> docs = provider.GetSigned();
                foreach (Document doc in docs)
                    jsonReply.ReadyCompleted.Add(doc.DocumentID);

                docs = provider.GetRejected();
                foreach (Document doc in docs)
                    jsonReply.ReadyDeclined.Add(doc.DocumentID);

                return Ok(jsonReply);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new TheError(ex.Message, TheErrorSource.Provider, ex.StackTrace));
            }
        }

        // GET documents with a document downloads the document
        // called from content connector when saving a signed document
        [HttpGet("Documents/{documentid}")]
        public ActionResult DownloadDocument(string documentid, [FromQuery] string context, [FromQuery] int content)
        {
            try
            {
                string username = Request.Headers["username"]; //can be empty when only an API key is needed
                string password = Request.Headers["password"];
                string providerURL = Request.Headers["providerUrl"];
                if (password == "" || providerURL == "")
                    return StatusCode(StatusCodes.Status400BadRequest, new TheError("Login information missing", TheErrorSource.Service));
                ActionResult errRes = ValidateToken();
                if (errRes != null)
                    return errRes;
                if (context == null)
                    context = "";

                FakeProvider provider = new FakeProvider();
                Document doc = provider.GetDocument(documentid);
                if (doc == null)
                    return StatusCode(StatusCodes.Status404NotFound, new TheError("Document does not exist.", TheErrorSource.Provider));
                if(doc.Context == context)
                    return Ok(new DownloadDocumentResponse(true));//the content connector will save the document
                else
                    return Ok(new DownloadDocumentResponse(false));//the content connector will continue with the next job
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new TheError(ex.Message, TheErrorSource.Provider, ex.StackTrace));
            }
        }

        // GET URLs for uploaded documents to view in browser control in the Viewer
        // called from Viewer when clicking on the View button in the eSignature Status dialog
        [HttpGet("Documents/{documentid}/URL")]
        public ActionResult GetDocumentURL(string documentid)
        {
            try
            {
                string username = Request.Headers["username"]; //can be empty when only an API key is needed
                string password = Request.Headers["password"];
                string providerURL = Request.Headers["providerUrl"];
                if (password == "" || providerURL == "")
                    return StatusCode(StatusCodes.Status400BadRequest, new TheError("Login information missing", TheErrorSource.Service));
                ActionResult errRes = ValidateToken();
                if (errRes != null)
                    return errRes;                

                FakeProvider provider = new FakeProvider();
                Document doc = provider.GetDocument(documentid);
                if (doc == null)
                    return StatusCode(StatusCodes.Status404NotFound, new TheError("Document does not exist.", TheErrorSource.Provider));

                return Ok(new URLResponse {ReturnURL = "http://localhost:5000/Custom", ViewURL = "http://localhost:5000/Custom" });//modify URLs - ReturnURL is for automatically closing the browser window, ViewURL
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new TheError(ex.Message, TheErrorSource.Provider, ex.StackTrace));
            }
        }

        // POST notifications is used for handling push notifications from the provider
        // there is no need for a token validation because this is never called from the Therefore™ Server
        // needs to forward the call to the Therefore™ Web API
        // returning error messages doesn't make sense as this is called from the provider
        [HttpPost("Notifications/{tenantName?}")]
        public ActionResult PushNotification(string tenantName = null)
        {
            StreamReader reader = null;
            try
            {
                /*the body of push notification of the fake provider looks like this:
                
                {
                    id = "documentid"
                }
                
                */
                PushNotification doc = (PushNotification)JsonConvert.DeserializeObject(reader.ReadToEnd());
                if (string.IsNullOrEmpty(_options.Value.WebAPIURL))
                {
                    _logger.LogError("WebAPIURL is not set. The WebAPIURL needs to be set in appsettings.json for PushNotifications to work. Use the REST endpoint of the WebAPI.\nPushNotifications for Tenant {0} with id {1} is ignored.", tenantName, doc.id);
                    return Ok();
                }

                HttpRequestMessage req = new HttpRequestMessage();
                req.Method = HttpMethod.Post;
                req.RequestUri = new Uri(new Uri(_options.Value.WebAPIURL), "HandleESignaturePushNotification");// Therefore Web API method for pushing eSignature notifications
                req.Headers.Add("TenantName", tenantName);

                string jsonMsg = JsonConvert.SerializeObject(new PushNotificationMessage(doc.id));
                req.Content = new StringContent(jsonMsg, System.Text.Encoding.UTF8, "application/json");
                Task<HttpResponseMessage> resp = _client.SendAsync(req, HttpCompletionOption.ResponseHeadersRead);
                HttpResponseMessage m = resp.Result;
                if (!m.IsSuccessStatusCode)
                {
                    _logger.LogError("Failed to send PushNotification to WebAPI: Status: {0}\nPushNotification for Tenant {1} with id {2}.", (int)m.StatusCode, tenantName, doc.id);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new TheError(ex.Message, TheErrorSource.Provider, ex.StackTrace));
            }
            finally
            {
                reader.Close();
            }
        }
    }
    public class EnvironmentVariables
    {
        public string WebAPIURL { get; set; }
    }

}
