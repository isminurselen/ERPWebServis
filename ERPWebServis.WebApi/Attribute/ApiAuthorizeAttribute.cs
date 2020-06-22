using ERPWebServis.Model;
using ERPWebServis.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ERPWebServis.WebApi.Attribute
{
    public class ApiAuthorizeAttribute: AuthorizeAttribute
    {

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // Etikette A ve U atandı. 
            var actionRoles = Roles;           
            
            var username = HttpContext.Current.User.Identity.Name;
            // httpcontxt geçerli user alıp rolunu kontrol ediyoruzu .Roles içinde varsa yetkilidir.
            var user = new BaseApiController<SETUP_USER>()._repo.Get().Where(c => c.USER_NAME == username).FirstOrDefault();
            
            if (user != null && Roles.Contains(user.USER_ROLE))
            {
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Unauthorized);

            }

                
        }

    }
}