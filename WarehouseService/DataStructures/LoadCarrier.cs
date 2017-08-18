using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DataStructures
{
    [XmlRoot("LoadCarriers")]
    public class LoadCarriers
    {
        [XmlElement("LoadCarrier")]
        public List<LoadCarrier> LoadCarrierList { get; set; }
    }

    
    public class LoadCarrier
    {
        [XmlElement("X")]
        public int X { get; set; }

        [XmlElement("Y")]
        public int Y { get; set; }

        [XmlElement("Z")]
        public int Z { get; set; }

        [XmlElement("ID")]
        public float ID { get; set; }

        [XmlElement("Location")]
        public string Location { get; set; }

        [XmlElement("Lock")]
        public bool Lock { get; set; }

        [XmlElement("LockReason")]
        public string LockReason { get; set; }
    }
}
