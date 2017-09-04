using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Description;
using MyServiceUtilities;

namespace MyPro
{
    public partial class MyService : ServiceBase
    {
        private PrintAutomator printAutomator;

        public MyService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            printAutomator = new PrintAutomator("*.pdf|*.txt", @"D:\Users\aneta\Desktop", "");
            printAutomator.StartWatching();
        }

        protected override void OnStop()
        {
            printAutomator.StartWatching();
        }
    }
}
