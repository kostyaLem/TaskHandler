using System.Web.Http;
using TaskHandler.Api.Infrastructure;

namespace TaskHandler.Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            AutofacWebapiConfig.Initialize(GlobalConfiguration.Configuration);

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
