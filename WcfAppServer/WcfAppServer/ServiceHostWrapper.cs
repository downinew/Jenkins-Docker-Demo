using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace WcfAppServer
{
    public class ServiceHostWrapper : MarshalByRefObject
    {
        private ServiceHost _serviceHost;
        public void CreateHost(Type serviceType, Type implementedContract,
          Uri address, bool useDebugSettings)
        {
            _serviceHost = new ServiceHost(serviceType, address);

            Binding binding = WcfHelper.GetBinding(address.ToString(), false);

            _serviceHost.AddServiceEndpoint(implementedContract, binding, address);

            if (useDebugSettings)
                SetupMexAndDebugBehaviour(address);
        }

        private void SetupMexAndDebugBehaviour(Uri address)
        {
            var serviceMetadataBehavior =
          _serviceHost.Description.Behaviors.Find<ServiceMetadataBehavior>();

            if (serviceMetadataBehavior == null)
            {
                serviceMetadataBehavior = new ServiceMetadataBehavior();
                _serviceHost.Description.Behaviors.Add(serviceMetadataBehavior);
            }

            _serviceHost.AddServiceEndpoint(typeof(IMetadataExchange),
          WcfHelper.GetBinding(address.ToString(), true), "MEX");

            var serviceDebugBehavior =
          _serviceHost.Description.Behaviors.Find<ServiceDebugBehavior>();

            if (serviceDebugBehavior == null)
            {
                serviceDebugBehavior = new ServiceDebugBehavior()
                {
                    IncludeExceptionDetailInFaults = true
                };
                _serviceHost.Description.Behaviors.Add(serviceDebugBehavior);
            }
        }

        public void Open()
        {
            _serviceHost.Open();
        }

        public void Close()
        {
            _serviceHost.Close();
        }

        public void Abort()
        {
            _serviceHost.Abort();
        }
    }
}