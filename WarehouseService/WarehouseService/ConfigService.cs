using System.Collections.Generic;
using System.ServiceModel.Activities;

namespace WarehouseService
{
    public class ConfigService
    {
        public static List<WSServiceConfig> GetWSServiceConfigs()
        {
            return new List<WSServiceConfig>(2)
                {
                new WSServiceConfig()
                {
                    Endpoint = "net.tcp://localhost:8732/WcfServiceLibrary1/Service1",
                    WSService = new WSService("WcfServiceLibrary1", "Service1", "WcfServiceLibrary1", "IService1")
                }
              };
        }
    }
}