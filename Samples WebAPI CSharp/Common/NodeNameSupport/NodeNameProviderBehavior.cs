using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;

namespace Common.NodeNameSupport
{
    /// <summary>
    /// Use this behavior to pass node name to the web service via the The-Node-Name HTTP header.
    /// </summary>
    public class NodeNameProviderBehavior : IEndpointBehavior
    {
        /// <summary>
        /// Gets or sets node name
        /// </summary>
        public string NodeName { get; set; }

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            // Nothing special here
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new NodeNameProviderMessageInspector(NodeName));
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
