using DataStructures;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Tools;

namespace WcfServiceLibrary1
{
    public class Service1 : IService1
    {

        private static string WarehouseService = "[Warehouse Service]";

        public string DetermineLoadCarrierDestination(LoadCarrier loadCarrier)
        {
            LogWriter.WriteLog($"{WarehouseService}[{nameof(DetermineLoadCarrierDestination)}] Checking Load Carrier Dimensions: {loadCarrier.ID}");

            if (loadCarrier.X > 600 || loadCarrier.X < 300)
            {
                loadCarrier.Lock = true;
                loadCarrier.LockReason = "Failed X Dimension";
            }

            if (loadCarrier.Y > 300 || loadCarrier.Y < 100)
            {
                loadCarrier.Lock = true;
                loadCarrier.LockReason = "Failed Y Dimension";
            }

            if (loadCarrier.Z > 600 || loadCarrier.Z < 300)
            {
                loadCarrier.Lock = true;
                loadCarrier.LockReason = "Failed Z Dimension";
            }

            if (loadCarrier.Lock)
            {
                LogWriter.WriteLog($"{WarehouseService}[{nameof(DetermineLoadCarrierDestination)}] Load Carrier: {loadCarrier.ID} failed dimensions: {loadCarrier.LockReason}. Sending to Aisle Reject");
                return "AisleReject";
            }

            LogWriter.WriteLog($"{WarehouseService}[{nameof(DetermineLoadCarrierDestination)}] Sending Load Carrier {loadCarrier.ID} into Aisle.");
            return "Storage";
        }

        public void StoreLoadCarrier(LoadCarrier loadCarrier)
        {
            LogWriter.WriteLog($"{WarehouseService}[{nameof(StoreLoadCarrier)}] Storing Load Carrier: {loadCarrier.ID} in {loadCarrier.Location}");
            LoadCarrierXmlWriter writer = new LoadCarrierXmlWriter();
            writer.WriteToXml(loadCarrier);
        }

        public string WhereIsLoadCarrier(string loadCarrierID)
        {
            string location;

            XmlSerializer serializer = new XmlSerializer(typeof(LoadCarriers));
            using (FileStream fileStream = new FileStream(@"D:\Bitbucket\WarehouseService\Load Carriers\LoadCarriers.xml", FileMode.Open))
            {
                LoadCarriers result = (LoadCarriers) serializer.Deserialize(fileStream);

                location = result.LoadCarrierList.Where(x => x.ID.ToString() == loadCarrierID).Select(x => x.Location).FirstOrDefault();
                fileStream.Flush();
                fileStream.Close();
            }

            return location;
        }
    }
}
