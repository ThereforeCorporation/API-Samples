using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace Therefore.CallAzureFunction
{    public class TheReqParams
    {
        public int TheInstanceNo { get; set; }
        public int TheTokenNo { get; set; }
        public string TheWebAPIUrl
        {
            get { return theWebAPIUrl; }
            set { theWebAPIUrl = value.TrimEnd('/'); }
        }
        private string theWebAPIUrl;
        public string TheTenant { get; set; }
        public string TheAccessToken { get; set; }
        public int TheCaseNo { get; set; }
        public int TheDocNo { get; set; }
        public string TheSettings { get; set; }

        public static TheReqParams Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<TheReqParams>(json);
        }

        public bool IsCaseWF()
        {
            return TheCaseNo > 0;
        }

        public void LogWFInfo(ILogger log)
        {
            string callInfo = $"InstanceNo: {TheInstanceNo}, TokenNo: {TheTokenNo}, ";
            if (IsCaseWF())
                callInfo += $"CaseNo: {TheCaseNo}";
            else
                callInfo += $"DocNo: {TheDocNo}";
            log.LogInformation(callInfo);
        }
    }

    public class TheRespParams
    {
        public TheRespParams(string error = "", bool rountingDone = false)
        {
            TheError = error;
            TheRoutingDone = rountingDone;
            TheRetryAfterMin = 0;
        }
        public TheRespParams(int retryAfterMin, string error = "")
        {
            TheError = error;
            TheRoutingDone = false;
            TheRetryAfterMin = retryAfterMin;
        }
        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }

        public string TheError { get; set; }
        public bool TheRoutingDone { get; set; }
        public int TheRetryAfterMin { get; set; }

        public bool ShouldSerializeTheRetryAfterMin()
        {
            return (TheRetryAfterMin > 0); // no need to transfer/serialize if value is 0 or less 
        }
    }
}
