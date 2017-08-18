using System.Collections.Generic;
using System.ServiceModel.Activities;

namespace WcfAppServer
{
    public class ConfigService
    {
        public static List<WcfServiceConfig> GetWcfServiceConfigs()
        {
            return new List<WcfServiceConfig>(2)
                {
                new WcfServiceConfig()
                {
                    Endpoint = "net.tcp://localhost:8732/WcfServiceLibrary1/Service1",
                    WcfService = new WcfService("WcfServiceLibrary1", "Service1", "WcfServiceLibrary1", "IService1")
                },
                new WcfServiceConfig()
                {
                    Endpoint = "net.tcp://localhost:8733/WcfServiceLibrary2/Service1",
                    WcfService = new WcfService("WcfServiceLibrary2", "Service1", "WcfServiceLibrary2", "IService1")
                }
              };
        }
    }
}