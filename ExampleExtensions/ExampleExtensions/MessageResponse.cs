using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExampleExtensions
{
    public class MessageResponse
    {

        private string loadCarrierIsGood = "Load Carrier is Good";
        private string loadCarrierIsBad = "Load Carrier is Bad";
        private string loadCarrierIsStored = "Load Carrier is Stored";
        private string loadCarrierIsTransporting = "Load Carrier is Transporting";

        public string LoadCarrierIsGood
        {
            get
            {
                return loadCarrierIsGood;
            }
        }

        public string LoadCarrierIsBad
        {
            get
            {
                return loadCarrierIsBad;
            }
        }

        public string LoadCarrierIsStored
        {
            get
            {
                return loadCarrierIsStored;
            }
        }

        public string LoadCarrierIsTransporting
        {
            get
            {
                return loadCarrierIsTransporting;
            }
        }

    }
}
