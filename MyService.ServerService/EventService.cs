using System;
using System.Configuration;
using System.Diagnostics;
using System.ServiceProcess;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MyService.ServerService
{
    public partial class EventService : ServiceBase
    {
        private readonly Timer timer;
        public EventService()
        {
            InitializeComponent();
            this.timer = new Timer(int.Parse(ConfigurationManager.AppSettings["Interval"]));
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
            catch (Exception exc)
            {
                this.EventLog.WriteEntry(exc.ToString(), EventLogEntryType.Error);
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
