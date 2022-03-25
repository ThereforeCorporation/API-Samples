using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Common.TokenSupport
{
    class ConnectionTokenMessageInspector : IClientMessageInspector
    {
        private readonly string tokenPropertyName = "UseToken";
        private int useTokenPropertyValue;

        internal ConnectionTokenMessageInspector(int flag)
        {
            useTokenPropertyValue = flag;
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

            property.Headers[tokenPropertyName] = useTokenPropertyValue.ToString();

            return null;
        }
    }
}
