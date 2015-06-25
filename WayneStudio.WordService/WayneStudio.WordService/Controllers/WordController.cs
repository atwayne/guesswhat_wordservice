using System.Net;
using System.Net.Http;
using System.Web.Http;
using WayneStudio.WordService.DataStore;
using WayneStudio.WordService.Models;

namespace WayneStudio.WordService.Controllers
{
    public class WordController : AppController
    {
        [HttpPost]
        [Route("word/create")]
        public HttpResponseMessage Create(UpdateWordRequest request)
        {
            var engine = new WordEngine();
            engine.AddWords(request);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        [Route("word/list")]
        public HttpResponseMessage List()
        {
            var engine = new WordEngine();
            var wordList = engine.GetWordList();
            return Request.CreateResponse(HttpStatusCode.OK, wordList);
        }


        [HttpPost]
        [HttpOptions]
        [Route("word/expire")]
        public HttpResponseMessage Expire(UpdateWordRequest request)
        {
            var engine = new WordEngine();
            engine.Expire(request);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPost]
        [HttpOptions]
        [Route("word/block")]
        public HttpResponseMessage Block(UpdateWordRequest request)
        {
            var engine = new WordEngine();
            engine.Block(request);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}