using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Description;
using System.Text;

namespace Common.TokenSupport
{
    /// <summary>
    /// Use this behavior to pass connection token to the web service via Http Header.
    /// </summary>
    public class ConnectionTokenBehavior : IEndpointBehavior
    {
        /// <summary>
        /// Gets or sets token enabled flag (1 - enabled).
        /// </summary>
        public int Flag { get; set; }

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
            // Nothing special here
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, System.ServiceModel.Dispatcher.ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new ConnectionTokenMessageInspector(Flag));
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