using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Common.TenantSupport
{
    internal class TenantProviderMessageInspector : IClientMessageInspector
    {
        private readonly string tenantPropertyName = "TenantName";
        private string tenantPropertyValue;

        internal TenantProviderMessageInspector(string tenantName)
        {
            tenantPropertyValue = tenantName;
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

            property.Headers[tenantPropertyName] = tenantPropertyValue;

            return null;
        }
    }
}
