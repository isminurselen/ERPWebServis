using ERPWebServis.Model;
using ERPWebServis.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Security.Principal;
using System.Net.Http.Headers;
using System.Text;
using System.Net;

namespace ERPWebServis.WebApi
{
    public class ApiDelegatingHandler : DelegatingHandler
    {
        
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            /* query string üzerinden kilmlik dorulama
            // apikey querystringden almak
            var querystring = request.RequestUri.ParseQueryString();
            var apikey = querystring["apiKey"];
            // api keyi header almak 
            //var  apikey = request.Headers.GetValues("apiKey").FirstOrDefault();

            // kimlik doğrulmsı yapıp geçerli kullanıcıya apikey atadık.

            var user = new BaseApiController<SETUP_USER>()._repo.Get().Where(c => c.USER_PASSWORD == apikey).FirstOrDefault(); 
            if  (user !=null)
            {
                var pri = new ClaimsPrincipal(new GenericIdentity(user.USER_NAME,apikey));
                //read.CurrentPrincipal = principal;
                HttpContext.Current.User = pri;
            }
            return base.SendAsync(request, cancellationToken);
            */

            // basic Authenticate işelmemi ile kimlik dorulama
            var header = request.Headers.Authorization;
            if (header != null)
            {
                var parseValued = header;
                if (parseValued.Scheme.Equals("basic", System.StringComparison.OrdinalIgnoreCase) && parseValued.Parameter != null)
                {
                    AuthenticateUser(parseValued.Parameter);
                }
            }


            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized && !response.Headers.Contains("WWW-Authenticate"))
            {
                response.Headers.Add("WWW-Authenticate", "Basic");

            }

            return response;





        }
        

        private bool AuthenticateUser(string credentialValues)
        {           

            var isValid = false;

            try
            {
                var credentials = Encoding.GetEncoding("iso-8859-1").GetString(Convert.FromBase64String(credentialValues));
                var values = credentials.Split(':');
      

                var user = new BaseApiController<SETUP_USER>()._repo.Get().Where(c => c.USER_NAME == values[0]).FirstOrDefault();
                if (user != null)
                {
                    var principal = new ClaimsPrincipal(new GenericIdentity(user.USER_NAME, null));
                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current != null)
                        HttpContext.Current.User = principal;
                }


            }
            catch
            {
                isValid = false;
            }
            return isValid;

        }
    }
}