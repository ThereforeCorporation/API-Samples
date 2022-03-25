using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDKSamples.ESignature
{
    #region UploadDocument
    public class SigningInformation
    {
        [JsonProperty(PropertyName = "subject")]
        public string Subject { get; set; }
        [JsonProperty(PropertyName = "template")]
        public string Template { get; set; }
        [JsonProperty(PropertyName = "context")]
        public string Context { get; set; }
        [JsonProperty(PropertyName = "setSigningOrder")]
        public bool SetSigningOrder { get; set; }
        [JsonProperty(PropertyName = "recipients")]
        public List<Dictionary<string, string>> Recipients { get; set; }
        [JsonProperty(PropertyName = "additionalSettings")]
        public Dictionary<string, string> AdditionalSettings { get; set; }
        [JsonProperty(PropertyName = "templateFields")]
        public Dictionary<string, string> TemplateFields { get; set; }
        [JsonProperty(PropertyName = "filesToSign")]
        public List<FileToSign> FilesToSign { get; set; }
        [JsonProperty(PropertyName = "notificationUrl")]
        public string PushNotificationURL { get; set; } //This is the service url only, with no functions, e.g https://machine:1234
        [JsonProperty(PropertyName = "tenant")]
        public string TenantName { get; set; }
        [JsonProperty(PropertyName = "manual")]
        public bool Manual { get; set; }

        public SigningInformation()
        {
            Subject = "";
            Template = "";
            Context = "";
            SetSigningOrder = false;
            Recipients = new List<Dictionary<string, string>>();
            AdditionalSettings = new Dictionary<string, string>();
            TemplateFields = new Dictionary<string, string>();
            FilesToSign = new List<FileToSign>();
            PushNotificationURL = "";
            TenantName = "";
            Manual = false;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public struct FileToSign
    {
        public FileToSign(string strOriginalName, string strFileBase64)
        {
            OriginalName = strOriginalName;
            FileBase64 = strFileBase64;
        }

        [JsonProperty(PropertyName = "originalName")]
        public string OriginalName { get; set; }
        [JsonProperty(PropertyName = "fileBase64")]
        public string FileBase64 { get; set; }
    }

    public class UploadDocumentResponse
    {
        public UploadDocumentResponse(string id)
        {
            Id = id;
        }

        public UploadDocumentResponse(string id, URLResponse url)
        {
            Id = id;
            URL = url;
        }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "url", NullValueHandling = NullValueHandling.Ignore)]
        public URLResponse URL { get; set; }
    }

    public class URLResponse
    {
        [JsonProperty(PropertyName = "viewUrl")]
        public string ViewURL { get; set; }

        [JsonProperty(PropertyName = "returnUrl")]
        public string ReturnURL { get; set; }

        public URLResponse()
        {
            ViewURL = "";
            ReturnURL = "";
        }
    }
    #endregion

    #region GetDocuments

    public class GetDocumentsResponse
	{
		public GetDocumentsResponse()
		{
			ReadyCompleted = new List<string>();
			ReadyDeclined = new List<string>();
		}

        /// <summary>
        /// The authority ids of the completed documents; these should be processed by Content Connector
       /// </summary>
        [JsonProperty(PropertyName = "readyCompleted")]
        public List<string> ReadyCompleted
		{
			get;set;
		}

        // The authority ids of the declined documents; these should be processed by Content Connector
        [JsonProperty(PropertyName = "readyDeclined")]
        public List<string> ReadyDeclined
		{
			get;set;
		}
    }
    #endregion

    #region DownloadDocument
    
    public class FileInfo
    {
        public FileInfo()
        {
        }

        [JsonProperty(PropertyName = "name")]
        public string Name
        { get; set; }

        [JsonProperty(PropertyName = "base64")]
        public string Base64
        { get; set; }
    }

    public class DownloadDocumentResponse
    {
        public DownloadDocumentResponse()
        { }

        public DownloadDocumentResponse(bool canProcess)
        {
            CanProcess = canProcess;
        }

        /// <summary>
        /// true if the item can be processed;
        /// false otherwise; the next profile in the job will then be tried.
        /// </summary>
        [JsonProperty(PropertyName = "canProcess")]
        public bool CanProcess
        { get; set; }

        /// <summary>
        /// the files to save for this item. Can be null if no files should be saved.
        /// </summary>
        [JsonProperty(PropertyName = "filesToSave")]
        public List<FileInfo> FilesToSave
        { get; set; }

        /// <summary>
        /// An arbitrary status that can later be used in the indexing profile.
        /// </summary>
        [JsonProperty(PropertyName = "status")]
        public string Status
        { get; set; }

        /// <summary>
        /// Any json data you want to access in the indexing profile. Optional
        /// </summary>
        [JsonProperty(PropertyName = "customJson")]
        public string CustomJson
        { get; set; }
    }
    #endregion
}
