using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;


namespace Careysoft.Dotnet.Server.MessageServer.Svc
{
    [RunInstaller(true)]
    public partial class InstallerMessageServer : System.Configuration.Install.Installer
    {
        public InstallerMessageServer()
        {
            InitializeComponent();
        }
    }
}
