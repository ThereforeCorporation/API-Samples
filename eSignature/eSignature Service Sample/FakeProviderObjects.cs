using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDKSamples.ESignature
{
    //this class is for holding document data
    public class Document
    {
        public string DocumentID { get; set; } //the document id at the fake provider
        public string Data { get; set; } //the document data base64 encoded
        public string Filename { get; set; }
        public string Context { get; set; }
        public DocumentState State { get; set; }

        public Document()
        {
            State = DocumentState.New;
        }
    }

    public enum DocumentState
    {
        New = 0,
        Signed = 1,
        Rejected = 2
    }

    public class Template
    {
        public string TemplateID { get; set; } //the template id at the fake provider; will be stored with the workflow config
        public string Name { get; set; } //the template name; will be displayed in the "Send for Signing" workflow task
        public List<TemplateProperty> Fields { get; set; } //the template fields
    }

    public class PushNotification
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
    }
}
