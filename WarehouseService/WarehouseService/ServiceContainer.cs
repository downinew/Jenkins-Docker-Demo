using System;
using System.Collections.Generic;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Activities;
using System.ServiceProcess;

namespace WarehouseService
{
    public class ServiceContainer : ServiceBase
    {
        public List<IsolatedServiceHost> IsolatedServiceHosts { get; set; }
        public WorkflowServiceHost WorkflowServiceHost { get; set; }

        protected override void OnStart(string[] args)
        {
            var configs = ConfigService.GetWSServiceConfigs();
            IsolatedServiceHosts = new List<IsolatedServiceHost>(configs.Count);

            foreach (var config in configs)
            {
                var isolatedServiceHost = CreateIsolatedServiceHost(config);

                isolatedServiceHost.Open();

                IsolatedServiceHosts.Add(isolatedServiceHost);
            }
        }

        private IsolatedServiceHost CreateIsolatedServiceHost(WSServiceConfig config)
        {
            var service = config.WSService;
            var assembly = Assembly.ReflectionOnlyLoad(service.ServiceAssemblyName);
            var serviceType = assembly.GetType(string.Format("{0}.{1}",
                service.ServiceAssemblyName, service.ServiceClassName));
            var implementedContractType = assembly.GetType(string.Format("{0}.{1}", 
                service.ServiceAssemblyName, service.ContractClassName));

            var appDomainName = string.Format("{0}.{1}",
                serviceType.AssemblyQualifiedName, config.Endpoint);

            return new IsolatedServiceHost(appDomainName,
                                           serviceType,
                                           implementedContractType,
                                           new Uri(config.Endpoint),
                                           true);
        }

        protected override void OnStop()
        {
            foreach (var isolatedServiceHost in IsolatedServiceHosts)
            {
                if (isolatedServiceHost == null)
                    continue;

                if (isolatedServiceHost.State == CommunicationState.Opened)
                    isolatedServiceHost.Close();
            }

            WorkflowServiceHost.Close();
        }
    }
}