using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SDKSamples.ESignature
{
    public class ProviderInfo
    {
        [JsonProperty(PropertyName = "templates")]
        public Dictionary<string, string> Templates { get; set; }
        [JsonProperty(PropertyName = "signerProperties")]
        public List<SettingProperty> SignerProperties { get; set; }
        [JsonProperty(PropertyName = "supportedWorkflowFeatures")]
        public WorkflowFeatures SupportedWorkflowFeatures { get; set; }
        [JsonProperty(PropertyName = "documentProperties")]
        public List<SettingProperty> DocumentProperties { get; set; }
		[JsonProperty(PropertyName = "downloadContentOptions")]
		public List<ContentOption> DownloadContentOptions { get; set; }

        public ProviderInfo()
        {
            Templates = new Dictionary<string, string>();
            SignerProperties = new List<SettingProperty>();
            DocumentProperties = new List<SettingProperty>();
            SupportedWorkflowFeatures = new WorkflowFeatures();
			DownloadContentOptions = new List<ContentOption>();
        }
    }

    public class SettingProperty
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "display")]
        public object Display { get; set; }
        [JsonProperty(PropertyName = "mandatory")]
        public bool Mandatory { get; set; }
        [JsonProperty(PropertyName = "options")]
        public Dictionary<string, string> Options { get; set; }
    }

    public class WorkflowFeatures
    {
        [JsonProperty(PropertyName = "subject")]
        public bool Subject { get; set; }
        [JsonProperty(PropertyName = "context")]
        public bool Context { get; set; }
        [JsonProperty(PropertyName = "forcePdfConversion")]
        public bool ForcePDFConversion { get; set; }
        [JsonProperty(PropertyName = "signingOrder")]
        public bool SigningOrder { get; set; }
        [JsonProperty(PropertyName = "templateFields")]
        public bool TemplateFields { get; set; }
        [JsonProperty(PropertyName = "predefinedTemplateFields")]
        public bool PredefinedTemplateFields { get; set; }
        public WorkflowFeatures()
        {
            Subject = true;
            Context = true;
            ForcePDFConversion = false;
            SigningOrder = false;
            TemplateFields = false;
            PredefinedTemplateFields = false;
        }
    }

    // ContentOption is used in the Signature Monitoring configuration only
	public class ContentOption
	{
		public ContentOption(int id, int resourceId)
		{
			Id = id;
			Name = resourceId;
		}

		[JsonProperty(PropertyName = "id")]
		public int Id
		{ get; set; }

		[JsonProperty(PropertyName = "name")]
		public object Name
		{ get; set; }
	}
}
