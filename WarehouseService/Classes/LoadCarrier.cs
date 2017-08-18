using System;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace Classes
{
    public class LoadCarrier
    {
        public int X { get; set; }
 
        public int Y { get; set; }

        public int Z { get; set; }

        public float ID { get; set; }

        public string Location { get; set; }

        public bool Lock { get; set; }

        public string LockReason { get; set; }
    }
}
