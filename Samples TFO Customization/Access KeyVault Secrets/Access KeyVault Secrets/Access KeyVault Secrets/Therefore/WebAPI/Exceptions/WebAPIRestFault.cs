using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Therefore.WebAPI.Exceptions
{
    public class WebAPIRestFault : WSFaultDetails
    {
        public static bool TryDeserialize(string str, out WSFaultDetails fault)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(WSFaultDetails));
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(str)))
            {
                try
                {
                    fault = (WSFaultDetails)serializer.ReadObject(stream);
                    return true;
                }
                catch (Exception e)
                {
                    Debug.WriteLine("Error while deserializing WSError: " + e.ToString());
                }
            }

            fault = null;
            return false;
        }
    }
}
