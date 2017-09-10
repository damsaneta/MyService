using System.Diagnostics;

namespace MyService.WebApi
{
    using System.Web.Http;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //if (!EventLog.SourceExists("MyService.WebApi"))
            //{
            //    EventLog.CreateEventSource("Application", "MyService.WebApi");
            //}

            //EventLog.WriteEntry("MyService.WebApi", "Aplikacja uruchomiona");
        }
    }
}
