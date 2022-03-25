using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;

namespace Common.CredentialsSupport
{
    /// <summary>
    /// Use this behavior to pass encoding (code page number) of the credentials to the web service via Http Header.
    /// </summary>
    public class CredentialsCodePageProviderBehavior : IEndpointBehavior
    {
        /// <summary>
        /// Gets or sets number of the code page. Please see list of codes in the Web API Documentation.
        /// </summary>
        public int CodePageNumber { get; set; }

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            // Nothing special here
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new CredentialsCodePageProviderMessageInspector(CodePageNumber));
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.EndpointDispatcher endpointDispatcher)
        {
            // Nothing special here
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            // Nothing special here
        }
    }
}

