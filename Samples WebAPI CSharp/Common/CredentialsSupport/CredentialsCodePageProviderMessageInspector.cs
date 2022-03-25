using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace Common.CredentialsSupport
{
    internal class CredentialsCodePageProviderMessageInspector : IClientMessageInspector
    {
        private readonly string credentialsCodePagePropertyName = "Therefore-Auth-Codepage";
        private int codePage;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codePage">Number of code page. Please see list of codes in the Web API Documentation.</param>
        /// <see cref="https://msdn.microsoft.com/en-us/library/system.text.encoding(v=vs.110).aspx#Anchor_5"/>
        internal CredentialsCodePageProviderMessageInspector(int codePage)
        {
            this.codePage = codePage;
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

            property.Headers[credentialsCodePagePropertyName] = codePage.ToString();

            return null;
        }
    }
}

