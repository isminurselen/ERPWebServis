using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace ERPWebServis.WebApi
{
    public class ApiKeyHandler:DelegatingHandler
    {
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var querystring = request.RequestUri.ParseQueryString();
            var apikey = querystring["Apikey"];




            return base.SendAsync(request, cancellationToken);
        }
    }
}