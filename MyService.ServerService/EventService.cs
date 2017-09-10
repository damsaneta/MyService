using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MyService.ServerService
{
    public partial class EventService : ServiceBase
    {
        private readonly Timer timer = new Timer(10000);
        public EventService()
        {
            InitializeComponent();
            this.timer.Elapsed += TimerOnElapsed;
            timer.Start();
        }

        private void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var job = new SendMailJob();
            try
            {
                job.DoJob();
            }
            catch (Exception)
            {
            }
        }

        protected override void OnStart(string[] args)
        {
            EventLog.WriteEntry("Uruchomienie serwisu MyService");
        }

        protected override void OnStop()
        {
            EventLog.WriteEntry("Zatrzymanie serwisu MyService");
        }
    }
}
