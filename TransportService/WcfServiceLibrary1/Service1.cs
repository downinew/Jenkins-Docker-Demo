using System;
using System.IO;
using WcfServiceLibrary1.WarehouseService;
using System.Threading;
using Tools;

namespace WcfServiceLibrary1
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class Service1 : IService1
    {

        private static string TransportService = "[Transport Service]";


        public bool StartCrossCommunication()
        {

            LogWriter.WriteLog($"{TransportService}[{nameof(StartCrossCommunication)}] Starting the Cross Channel Communication");

            File.Delete(@"D:\Bitbucket\WarehouseService\Load Carriers\LoadCarriers.xml");

            Service1Client client = new Service1Client();
            Random rnd = new Random();

            int j = 0;

            for (int i = 0; i < 10; i++)
            {
                LoadCarrier loadCarrier = new LoadCarrier
                {
                    ID = j,
                    Location = "AisleSorter",
                    Lock = false,
                    LockReason = null,
                    X = rnd.Next(200, 700),
                    Y = rnd.Next(1, 400),
                    Z = rnd.Next(200, 700)
                };

                j++;

                client.StoreLoadCarrier(loadCarrier);

                LogWriter.WriteLog($"{TransportService}[{nameof(StartCrossCommunication)}] Sending Load Carrier: {loadCarrier.ID} @ {loadCarrier.Location} " +
                    $"with [X, Y, Z] : [{loadCarrier.X}, {loadCarrier.Y}, {loadCarrier.Z}]");

                Thread.Sleep(1000);
            }



            LogWriter.WriteLog($"{TransportService}[{nameof(StartCrossCommunication)}] Ending the Cross Channel Communication");

            return true;
        }

        public string ObeyOrder()
        {
            throw new NotImplementedException();
        }

        public string SendTelegram()
        {
            throw new NotImplementedException();
        }

        public string UseExtensions()
        {
            return "Using Extensions";
        }

    }
}
