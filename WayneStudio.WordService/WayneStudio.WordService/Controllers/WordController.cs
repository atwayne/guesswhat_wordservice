using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace WayneStudio.WordService.Controllers
{
    public class WordController : AppController
    {
        [HttpGet]
        [Route("wordlist")]
        public HttpResponseMessage List()
        {
            
        }
    }
}