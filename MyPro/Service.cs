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
using System.Threading;
using MyServiceUtilities;

namespace MyPro
{
    public partial class MyService : ServiceBase
    {
        //private PrintAutomator printAutomator;

        public MyService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var t= new Thread(() => { 
                var printAutomator = new PrintAutomator("*.txt", @"D:\Users\aneta\Desktop\test", "");
                 printAutomator.StartWatching();
            });
            t.Start();
            
        }

        protected override void OnStop()
        {
           // printAutomator.StartWatching();
        }
    }
}
