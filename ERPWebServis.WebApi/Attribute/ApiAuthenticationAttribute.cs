using ERPWebServis.Model;
using ERPWebServis.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ERPWebServis.WebApi.Attribute
{
    public class ApiAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)


        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                /*
                if (actionContext.Response.StatusCode == HttpStatusCode.Unauthorized && !actionContext.Response.Headers.Contains("WWW-Authenticate"))
                {
                    actionContext.Response.Headers.Add("WWW-Authenticate", "Basic");
                }
                */
            }
            else
            {
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string decodeauthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
              //  var values = decodeauthenticationToken.Split(':');
                string[] values = decodeauthenticationToken.Split(':');
                string username = values[0];
                string password = values[1];

                var user = new BaseApiController<SETUP_USER>()._repo.Get().Where(c => c.USER_NAME == username && c.USER_PASSWORD==password);
                if (user != null)
                {                    
                    var principal = new GenericPrincipal(new GenericIdentity(username), null);
                    Thread.CurrentPrincipal = principal;
                    if (HttpContext.Current != null)
                        HttpContext.Current.User = principal;
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

            }
            base.OnAuthorization(actionContext);
        }
    }
}
