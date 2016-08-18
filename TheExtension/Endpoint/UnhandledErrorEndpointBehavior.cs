using System;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using TheContracts;

namespace TheExtension.Endpoint
{
    public class UnhandledErrorEndpointBehavior : IEndpointBehavior
    {
        private static readonly Type UnhandledErrorType = typeof(UnhandledError);

        /// <summary>Implement to confirm that the endpoint meets some intended criteria.</summary>
        /// <param name="endpoint">The endpoint to validate.</param>
        public void Validate(ServiceEndpoint endpoint)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        /// <summary>Implements a modification or extension of the service across an endpoint.</summary>
        /// <param name="endpoint">The endpoint that exposes the contract.</param>
        /// <param name="endpointDispatcher">The endpoint dispatcher to be modified or extended.</param>
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            foreach (var dispatchOperation in endpointDispatcher.DispatchRuntime.Operations)
            {
                if (dispatchOperation.FaultContractInfos.Any(faultContractInfo => faultContractInfo.Detail == UnhandledErrorType))
                    continue;

                var action = dispatchOperation.Action + UnhandledErrorType.Name + "Fault";
                dispatchOperation.FaultContractInfos.Add(new FaultContractInfo(action, UnhandledErrorType));
            }
        }

        /// <summary>Implements a modification or extension of the client across an endpoint.</summary>
        /// <param name="endpoint">The endpoint that is to be customized.</param>
        /// <param name="clientRuntime">The client runtime to be customized.</param>
        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            foreach (var clientOperation in clientRuntime.ClientOperations)
            {
                if (clientOperation.FaultContractInfos.Any(faultContractInfo => faultContractInfo.Detail == UnhandledErrorType))
                    continue;

                var action = clientOperation.Action + UnhandledErrorType.Name + "Fault";
                clientOperation.FaultContractInfos.Add(new FaultContractInfo(action, UnhandledErrorType));
            }
        }
    }
}
