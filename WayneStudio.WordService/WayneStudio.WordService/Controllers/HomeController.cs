using System.Net;
using System.Net.Http;
using System.Web.Http;
using WayneStudio.WordService.Core;

namespace WayneStudio.WordService.Controllers
{
    public class HomeController : AppController
    {
        [HttpGet]
        public HttpResponseMessage Index()
        {
            return Request.CreateResponse(HttpStatusCode.OK, ConnectionString);
        }

        [HttpGet]
        public HttpResponseMessage Test()
        {
            SQLiteHelper.CreateDatabaseIfNotExist();
            return Request.CreateResponse(HttpStatusCode.OK, "OK");
        }

        //[HttpGet]
        //[Route("home/{productName}/value")]
        //public HttpResponseMessage GetValueByProductName(string productName)
        //{
        //    return Request.CreateResponse(HttpStatusCode.OK, productName.ToUpper());
        //}
    }
}