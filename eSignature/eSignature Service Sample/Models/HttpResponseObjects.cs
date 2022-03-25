using System;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
//using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading;
using Newtonsoft.Json;

namespace SDKSamples.ESignature
{
    //ConnectionResult is to be returned when Connection is called.
    public class ConnectionResult
    {
        [JsonProperty(PropertyName = "connectedTo")]
        public string ConnectedTo { get; set; }
        
        public ConnectionResult()
        {
            ConnectedTo = "Therefore eSignature Service";  // shared custom string to ensure the response comes from our service
        }
    }

    //TheError is used for sending error messages back to Therefore. 
    //The error messages will be logged by the Content Connector or Workflow Engine or displayed in the UI in Designer.
    public class TheError
    {
        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "stackTrace")]
        public string StackTrace { get; set; }

        [JsonProperty(PropertyName = "from")]
        public string From { get; set; }

        public TheError(string message, TheErrorSource source, string stackTrace = "")
        {
            Message = message;
            StackTrace = stackTrace;
            From = source.ToString();
        }
    }
    
    public enum TheErrorSource
    {
        Service,
        Provider
    }

}
