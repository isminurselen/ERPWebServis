
using ERPWebServis.Model;
using ERPWebServis.WebApi.Controllers;
using System;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;

namespace ERPWebServis.WebApi
{
    public class ApiHttpModule : IHttpModule
    {
        public void Dispose()
        {
           
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += Context_AuthenticateRequest;
            context.EndRequest += Context_EndRequest; 
        }

        private void Context_AuthenticateRequest(object sender, System.EventArgs e)
        {
            var request = HttpContext.Current.Request;
            var header = request.Headers["Authorization"];
       

            if (header!=null)
            {
                var parseValued = AuthenticationHeaderValue.Parse(header);
                if (parseValued.Scheme.Equals("basic",System.StringComparison.OrdinalIgnoreCase) && parseValued.Parameter !=null)
                {
                    AuthenticateUser(parseValued.Parameter);
                }
            }

        }

        private bool AuthenticateUser(string credentialValues)
        {
            var isValid = false;
            
            try
            {
               var credentials = Encoding.GetEncoding("iso-8859-1").GetString(Convert.FromBase64String(credentialValues));
               var values = credentials.Split(':');
               isValid = CheckUser(userName:values[0],password:values[1]);

                if (isValid)
                    SetPrincipal(new GenericPrincipal(new GenericIdentity(values[0]), null));
                
            }
            catch
            {
                isValid = false;
            }
            return isValid;

        }

        private bool CheckUser(string userName,string password)
        {                                 
            return (userName=="burak" && password=="1234");                              

        }

        private void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current !=null)
              HttpContext.Current.User = principal;

        }




        private void Context_EndRequest(object sender, System.EventArgs e)
        {
            var repsonse = HttpContext.Current.Response;
            if  (repsonse.StatusCode==401)
            {
                repsonse.Headers.Add("WWW-Authenticate", "Basic realm=\"insert for realm\"");

            }               

        }



        
    }
}