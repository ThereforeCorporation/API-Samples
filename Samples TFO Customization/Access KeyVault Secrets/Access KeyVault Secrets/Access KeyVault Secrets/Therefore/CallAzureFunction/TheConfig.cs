using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Therefore.CallAzureFunction
{
    public class TheConfig
    {
        #region Singleton
        private static readonly TheConfig _Instance = new TheConfig();
        public static TheConfig Instance
        {
            get { return _Instance; }
        }
        #endregion

        // this is a singleton, so no constructor available for extern
        private TheConfig()
        {
            //Azure KeyVault settings:
            UseREST = true;
            Language = "en-US"; // language
            RequestTimeout = new TimeSpan(0, 0, 0, 40, 0); // consider that the HTTP-triggered Azure itself will time out after 230 seconds.
            ClientTimezoneIANA = "US/Central"; // timezone in IANA format (https://www.iana.org/time-zones)

            // read the app settings from the configuration file:
            var config = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true) // for development on local machine
             .AddEnvironmentVariables() // for Azure after deployment
             .Build();
            UserName = config["WebAPIUser"]; // username
            Password = config["WebAPIPassword"]; // password or token retrieved from GetConnectionToken Web API function (not the JWT 'accessToken')
            IsToken = false; // set to 'true' if 'password' is not a password but a token
            AzureAppId = config["Azure.AppId"];
            AzureAuthKey = config["Azure.AuthKey"]; 
            AzureKeyVaultUri = config["Azure.KeyVaultUri"];
        }

        public string WebAPIBaseUrl { get; set; }
        public string WebAPIUrl
        {
            get
            {
                if (String.IsNullOrEmpty(WebAPIBaseUrl))
                    throw new Exception("Web API base URL not set.");
                return WebAPIBaseUrl.TrimEnd('/') + "/v0001/" + (UseREST ? "restun" : "soapun");
            }
        }
        public bool UseREST { get; set; }
        public string Tenant { get; set; }
        public string Language { get; set; }
        public TimeSpan RequestTimeout { get; set; }
        public string ClientTimezoneIANA { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsToken { get; set; }
        public string AzureAppId { get; set; }
        public string AzureAuthKey { get; set; }
        public string AzureKeyVaultUri { get; set; }
    }
}
