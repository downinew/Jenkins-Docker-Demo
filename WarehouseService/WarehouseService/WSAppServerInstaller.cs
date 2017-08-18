using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace WarehouseService
{
    [RunInstaller(true)]
    public class WSApplicationServerInstaller : System.Configuration.Install.Installer
    {
        public WSApplicationServerInstaller()
        {
            var serviceProcessInstaller = new ServiceProcessInstaller()
            {
                Account = ServiceAccount.LocalSystem,
                Password = null,
                Username = null
            };

            var serviceInstaller = new ServiceInstaller()
            {
                DisplayName = "WarehouseService",
                ServiceName = "WarehouseService",
                StartType = ServiceStartMode.Manual
            };

            Installers.AddRange(new System.Configuration.Install.Installer[] {
                                  serviceProcessInstaller,
                                  serviceInstaller});

            AfterInstall += ServiceInstaller_AfterInstall;
        }

        void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            var serviceController = new ServiceController("WarehouseService");
            serviceController.Start();
        }
    }
}