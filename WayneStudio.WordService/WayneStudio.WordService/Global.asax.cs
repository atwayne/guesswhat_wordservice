using System.Web;
using System.Web.Http;
using WayneStudio.WordService.Core;

namespace WayneStudio.WordService
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);
        }
    }
}