using System.Web.Http;
using Newtonsoft.Json;

namespace WayneStudio.WordService.Core
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // attribute routing
            config.MapHttpAttributeRoutes();

            // convention-based routing.
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling
                = PreserveReferencesHandling.None;

            config.Formatters.Remove(config.Formatters.XmlFormatter);

            config.EnsureInitialized();

            config.MessageHandlers.Add(new OptionsHttpMessageHandler());

        }
    }
}
