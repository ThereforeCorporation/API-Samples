using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Common.NodeNameSupport
{
    internal class NodeNameProviderMessageInspector : IClientMessageInspector
    {
        private readonly string nodeNamePropertyName = "The-Node-Name";
        private string nodeNamePropertyValue;

        internal NodeNameProviderMessageInspector(string nodeName)
        {
            nodeNamePropertyValue = nodeName;
        }


        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
            // Nothing special here
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            HttpRequestMessageProperty property;

            if (request.Properties.ContainsKey(HttpRequestMessageProperty.Name))
                property = (HttpRequestMessageProperty)request.Properties[HttpRequestMessageProperty.Name];
            else
                request.Properties.Add(HttpRequestMessageProperty.Name, property = new HttpRequestMessageProperty());

            property.Headers[nodeNamePropertyName] = nodeNamePropertyValue;

            return null;
        }
    }
}
