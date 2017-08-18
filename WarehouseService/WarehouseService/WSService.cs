namespace WarehouseService
{
    public class WSService
    {
        public string Namespace { get; set; }
        public string ServiceAssemblyName { get; set; }
        public string ServiceClassName { get; set; }
        public string ContractAssemblyName { get; set; }
        public string ContractClassName { get; set; }

        public WSService()
        {
        }

        public WSService(string serviceAssemblyName, string serviceClassName,
          string contractAssemblyName, string contractClassName)
        {
            ServiceAssemblyName = serviceAssemblyName;
            ServiceClassName = serviceClassName;
            ContractAssemblyName = contractAssemblyName;
            ContractClassName = contractClassName;
        }
    }
}