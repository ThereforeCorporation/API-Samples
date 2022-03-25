using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AddFileAndRerouteWF
{
    class CustomSettings
    {
        public string UserInfo { get; set; }

        public string taskNo;
        public int TaskNo
        {
            get { return int.Parse(taskNo); }
            set { taskNo = value.ToString(); }
        }
        public static CustomSettings Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<CustomSettings>(json);
        }
    }
}
