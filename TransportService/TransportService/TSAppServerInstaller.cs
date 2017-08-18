using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace TransportService
{
    [RunInstaller(true)]
    public class TSApplicationServerInstaller : Installer
    {
        public TSApplicationServerInstaller()
        {
            var serviceProcessInstaller = new ServiceProcessInstaller()
            {
                Account = ServiceAccount.LocalSystem,
                Password = null,
                Username = null
            };

            var serviceInstaller = new ServiceInstaller()
            {
                DisplayName = "TransportService",
                ServiceName = "TransportService",
                StartType = ServiceStartMode.Manual
            };

            Installers.AddRange(new System.Configuration.Install.Installer[] {
                                  serviceProcessInstaller,
                                  serviceInstaller});

            AfterInstall += ServiceInstaller_AfterInstall;
        }

        void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            var serviceController = new ServiceController("TransportService");
            serviceController.Start();
        }
    }
}