using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using DataStructures;

namespace Tools
{
    public class LoadCarrierXmlWriter
    {

        public string Path { get; set; }

        public LoadCarrierXmlWriter()
        {
            Path = @"D:\Bitbucket\WarehouseService\Load Carriers\LoadCarriers.xml";
        }

        public LoadCarrierXmlWriter(string path)
        {
            Path = path;
        }

        public void WriteToXml(LoadCarrier loadcarrier)
        {
            if (File.Exists(Path) == false)
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create(Path, xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("LoadCarriers");

                    xmlWriter.WriteStartElement("LoadCarrier");
                    xmlWriter.WriteElementString("ID", loadcarrier.ID.ToString());
                    xmlWriter.WriteElementString("Location", loadcarrier.Location);
                    xmlWriter.WriteElementString("Lock", loadcarrier.Lock ? "1" : "0");
                    xmlWriter.WriteElementString("LockReason", loadcarrier.LockReason);
                    xmlWriter.WriteElementString("X", loadcarrier.X.ToString());
                    xmlWriter.WriteElementString("Y", loadcarrier.Y.ToString());
                    xmlWriter.WriteElementString("Z", loadcarrier.Z.ToString());
                    xmlWriter.WriteEndElement();

                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    xmlWriter.Flush();
                    xmlWriter.Close();
                }
            }
            else
            {
                XDocument xDocument = XDocument.Load(Path);
                XElement root = xDocument.Element("LoadCarriers");
                root.Add(
                    new XElement("LoadCarrier",
                    new XElement("ID", loadcarrier.ID.ToString()),
                    new XElement("Location", loadcarrier.Location),
                    new XElement("Lock", loadcarrier.Lock),
                    new XElement("LockReason", loadcarrier.LockReason),
                    new XElement("X", loadcarrier.X.ToString()),
                    new XElement("Y", loadcarrier.Y.ToString()),
                    new XElement("Z", loadcarrier.Z.ToString())));
                xDocument.Save(Path);
            }
        }



    }
}
