using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDKSamples.ESignature
{
	public class PushNotificationMessage
	{
		public PushNotificationMessage(string id)
		{
			UniqueId = id;
		}

		[JsonProperty(PropertyName = "UniqueId")]
		public string UniqueId
		{ get; set; }
	}

    public class GetSettingParams
    {
        [JsonProperty(PropertyName = "SettingKey")]
        public int SettingKey { get; set; }
    }

    public class GetSettingResponse
    {
        [JsonProperty(PropertyName = "SettingValue")]
        public String SettingValue { get; set; }
    }
    public class WSError
    {
        [JsonProperty(PropertyName = "ErrorId")]
        public string ErrorId { get; set; }

        [JsonProperty(PropertyName = "ErrorSource")]
        public int ErrorSource { get; set; }

        [JsonProperty(PropertyName = "ErrorCode")]
        public long? ErrorCode { get; set; }

        [JsonProperty(PropertyName = "ErrorCodeHex")]
        public string ErrorCodeHex { get; set; }

        [JsonProperty(PropertyName = "ErrorCodeString")]
        public string ErrorCodeString { get; set; }

        [JsonProperty(PropertyName = "ErrorMessage")]
        public string ErrorMessage { get; set; }
    }
}
