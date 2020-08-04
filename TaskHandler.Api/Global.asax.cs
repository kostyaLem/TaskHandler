using System.Web;
using System.Web.Http;
using TaskHandler.Api.Infrastructure;

namespace TaskHandler.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {           
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
