using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace WcfAppServer
{
    [RunInstaller(true)]
    public class WcfApplicationServerInstaller : System.Configuration.Install.Installer
    {
        public WcfApplicationServerInstaller()
        {
            var serviceProcessInstaller = new ServiceProcessInstaller()
            {
                Account = ServiceAccount.LocalSystem,
                Password = null,
                Username = null
            };

            var serviceInstaller = new ServiceInstaller()
            {
                DisplayName = "Wcf App Server",
                ServiceName = "ServiceContainer",
                StartType = ServiceStartMode.Manual
            };

            Installers.AddRange(new System.Configuration.Install.Installer[] {
                                  serviceProcessInstaller,
                                  serviceInstaller});

            AfterInstall += ServiceInstaller_AfterInstall;
        }

        void ServiceInstaller_AfterInstall(object sender, InstallEventArgs e)
        {
            var serviceController = new ServiceController("Wcf App Server");
            serviceController.Start();
        }
    }
}