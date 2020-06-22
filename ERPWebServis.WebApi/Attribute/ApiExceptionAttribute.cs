using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;
using System.Web.Http.Results;

namespace ERPWebServis.WebApi
{
    public class ApiExceptionAttribute:ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            message.ReasonPhrase = actionExecutedContext.Exception.Message;
            actionExecutedContext.Response = message;
            base.OnException(actionExecutedContext);
        }


        
    }
}