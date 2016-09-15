using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.ServiceProcess;

namespace MyPro
{
    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        private ServiceProcessInstaller proc;
        private ServiceInstaller service;


        public Installer()
        {
            proc = new ServiceProcessInstaller();
            proc.Account = ServiceAccount.LocalSystem;
            service = new ServiceInstaller();

            service.ServiceName = "MyService";
            service.DisplayName = "MyService";
            service.Description = "Automatic print service";

            service.StartType = ServiceStartMode.Automatic;

            Installers.Add(proc);
            Installers.Add(service);
        }
    }
}
