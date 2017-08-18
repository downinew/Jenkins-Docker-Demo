using System.Collections.Generic;
using System.ServiceModel.Activities;

namespace TransportService
{
    public class ConfigService
    {
        public static List<TSServiceConfig> GetWSServiceConfigs()
        {
            return new List<TSServiceConfig>(2)
                {
                new TSServiceConfig()
                {
                    Endpoint = "net.tcp://localhost:8733/WcfServiceLibrary1/Service1",
                    WSService = new TSService("WcfServiceLibrary1", "Service1", "WcfServiceLibrary1", "IService1")
                }
              };
        }
    }
}