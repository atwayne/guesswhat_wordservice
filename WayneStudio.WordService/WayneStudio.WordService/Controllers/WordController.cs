using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WayneStudio.WordService.Models;

namespace WayneStudio.WordService.Controllers
{
    public class WordController : AppController
    {
        [HttpPost]
        [Route("word/create")]
        public HttpResponseMessage Create(UpdateWordRequest request)
        {
            // TODO: save to database
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        [Route("word/list")]
        public HttpResponseMessage List()
        {
            // TODO: read from database
            var wordList = new List<string>() { "foo", "bar" };
            return Request.CreateResponse(HttpStatusCode.OK, wordList);
        }


        [HttpPost]
        [Route("word/expire")]
        public HttpResponseMessage List(UpdateWordRequest request)
        {
            // TODO: expire record
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPost]
        [Route("word/block")]
        public HttpResponseMessage List(UpdateWordRequest request)
        {
            // TODO: block record
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}