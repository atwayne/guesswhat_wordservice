using System.Configuration;
using System.Web.Http;
using WayneStudio.WordService.Core;

namespace WayneStudio.WordService.Controllers
{
    public class AppController : ApiController
    {
        public AppController()
        {
            SQLiteHelper.SetConnectionString(ConnectionString);
        }

        protected string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["appConnectionString"].ConnectionString; }
        }
    }
}