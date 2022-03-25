using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;

namespace Common.TenantSupport
{
    /// <summary>
    /// Use this behavior to pass Tenant Name to the web service via Http Header.
    /// </summary>
    public class TenantProviderBehavior : IEndpointBehavior
    {
        /// <summary>
        /// Gets or sets tenant name
        /// </summary>
        public string TenantName { get; set; }

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            // Nothing special here
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new TenantProviderMessageInspector(TenantName));
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
