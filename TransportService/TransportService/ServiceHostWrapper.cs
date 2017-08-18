using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace TransportService
{
    public class ServiceHostWrapper : MarshalByRefObject
    {
        private ServiceHost _serviceHost;
        public void CreateHost(Type serviceType, Type implementedContract,
          Uri address, bool useDebugSettings)
        {
            _serviceHost = new ServiceHost(serviceType, address);

            Binding binding = TSHelper.GetBinding(address.ToString(), false);

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
          TSHelper.GetBinding(address.ToString(), true), "MEX");

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
            _serviceHost.Opening += _serviceHost_Opening;
            
            _serviceHost.Open();
        }

        private void _serviceHost_Opening(object sender, EventArgs e)
        {
            throw new NotImplementedException();
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