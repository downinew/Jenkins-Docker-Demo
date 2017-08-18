using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace WcfAppServer
{
    public static class WcfHelper
    {
        public static Binding GetBinding(string address, bool isMexBinding)
        {
            if (isMexBinding)
            {
                if (address.StartsWith("net.tcp"))
                    return CreateMexNetTcpBinding();

                if (address.StartsWith("http://"))
                    return CreateMexHttpBinding();
            }
            else
            {
                if (address.StartsWith("net.tcp"))
                    return CreateTcpBinding();

                if (address.StartsWith("http://"))
                    return CreateWsHttpBinding();
            }
            throw new Exception("Cannot infer binding from address, please use net.tcp or http:// address");
      }

        private static Binding CreateTcpBinding()
        {
            var binding = new NetTcpBinding()
            {
                MaxReceivedMessageSize = 25 * 1024 * 1024,
                ReceiveTimeout = new TimeSpan(0, 2, 0)
            };
            return binding;
        }

        private static Binding CreateWsHttpBinding()
        {
            Binding binding = new WSHttpBinding();
            return binding;
        }

        private static Binding CreateMexHttpBinding()
        {
            return MetadataExchangeBindings.CreateMexHttpBinding();
        }

        private static Binding CreateMexNetTcpBinding()
        {
            return MetadataExchangeBindings.CreateMexTcpBinding();
        }
    }
}