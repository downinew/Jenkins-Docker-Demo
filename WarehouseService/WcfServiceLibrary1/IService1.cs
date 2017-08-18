using DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceLibrary1
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void StoreLoadCarrier(LoadCarrier loadCarrier);

        [OperationContract]
        string DetermineLoadCarrierDestination(LoadCarrier loadCarrier);

        [OperationContract]
        string WhereIsLoadCarrier(string loadCarrierID);

    }
}
