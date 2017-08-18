using System;
using System.Reflection;
using System.ServiceModel;

namespace WarehouseService
{
    public class IsolatedServiceHost : IDisposable
    {
        public string ServiceId { get; set; }

        ServiceHostWrapper _serviceHostWrapper;

        public event EventHandler Closed = delegate { };
        public event EventHandler Closing = delegate { };
        public event EventHandler Opened = delegate { };
        public event EventHandler Opening = delegate { };

        public CommunicationState State { get; set; }

        public IsolatedServiceHost(string serviceId, Type serviceType,
          Type implementedContract, Uri address, bool useDebugSettings)
        {
            State = CommunicationState.Faulted;

            this.ServiceId = serviceId;

            var appDomain = AppDomain.CreateDomain(serviceId);

            string assemblyName = Assembly.GetAssembly(typeof(ServiceHostWrapper)).FullName;

            _serviceHostWrapper = appDomain.CreateInstanceAndUnwrap
      (assemblyName, typeof(ServiceHostWrapper).ToString()) as ServiceHostWrapper;

            if (_serviceHostWrapper == null)
                throw new Exception(string.Format("Exception creating instance '{0}' from appdomain '{1}'", serviceType, appDomain.FriendlyName));

            _serviceHostWrapper.CreateHost(serviceType, implementedContract,
          address, useDebugSettings);

            State = CommunicationState.Created;
        }

        public void Open()
        {
            if (State != CommunicationState.Created)
                return;

            try
            {
                Opening(this, EventArgs.Empty);

                _serviceHostWrapper.Open();

                State = CommunicationState.Opened;

                Opened(this, EventArgs.Empty);
            }
            finally
            {
                State = CommunicationState.Faulted;
            }
        }

        public void Close()
        {
            if (State != CommunicationState.Opened)
                return;

            try
            {
                Closing(this, EventArgs.Empty);

                _serviceHostWrapper.Close();

                State = CommunicationState.Closed;

                Closed(this, EventArgs.Empty);
            }
            finally
            {
                State = CommunicationState.Faulted;
            }
        }

        public void Abort()
        {
            try
            {
                _serviceHostWrapper.Abort();
            }
            finally
            {
                State = CommunicationState.Faulted;
            }
        }

        void IDisposable.Dispose()
        {
            Close();
        }
    }
}