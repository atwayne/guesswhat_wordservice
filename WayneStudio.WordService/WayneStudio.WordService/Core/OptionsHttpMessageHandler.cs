using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace WayneStudio.WordService.Core
{
    public class OptionsHttpMessageHandler : DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.Method != HttpMethod.Options)
                return base.SendAsync(request, cancellationToken);

            var apiExplorer = GlobalConfiguration.Configuration.Services.GetApiExplorer();

            var controllerRequested = request.GetRouteData().Values["controller"] as string;
            var supportedMethods = new string[] { "POST","OPTIONS"};

            return Task.Factory.StartNew(() =>
            {
                var resp = new HttpResponseMessage(HttpStatusCode.OK);
                resp.Headers.Add(
                    "Access-Control-Allow-Methods", string.Join(",", supportedMethods));
                resp.Headers.Add("Access-Control-Allow-Headers",
                    "Origin, X-Requested-With, Content-Type, Accept, Authorization ");
                return resp;
            });
        }
    }
}