using System.ComponentModel;
using System.Configuration.Install;
using System.ServiceProcess;

namespace CoreExample.Windows
{
    [RunInstaller(true)]
    public class CoreExampleInstaller : Installer
    {
        public CoreExampleInstaller()
        {
            var processInstaller = new ServiceProcessInstaller();
            var serviceInstaller = new ServiceInstaller();

            //set the privileges
            processInstaller.Account = ServiceAccount.LocalSystem;

            serviceInstaller.DisplayName = "CoreExample";
            serviceInstaller.StartType = ServiceStartMode.Automatic;

            //must be the same as what was set in Program's constructor
            serviceInstaller.ServiceName = "CoreExample";
            this.Installers.Add(processInstaller);
            this.Installers.Add(serviceInstaller);
        }
    }
}