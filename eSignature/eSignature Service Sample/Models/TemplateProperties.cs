using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDKSamples.ESignature
{
    public class TemplateProperties
    {
        [JsonProperty (PropertyName = "templateFields")]
        public List<TemplateProperty> Fields { get; set; }

        public TemplateProperties()
        {
            Fields = new List<TemplateProperty>();
        }
    }

    public class TemplateProperty
    {
        [JsonProperty(PropertyName = "id")]
        public string ID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }
}
