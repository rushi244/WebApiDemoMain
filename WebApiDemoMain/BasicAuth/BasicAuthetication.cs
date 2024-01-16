using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using WebApiDemoMain.AuthFilter;

namespace WebApiDemoMain.BasicAuth
{
    public class BasicAuthetication:AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Failed");
            }
            else {
                try
                {
                    string authToken = actionContext.Request.Headers.Authorization.Parameter;
                    //username:password  base64 encoded
                    //admin:password

                    string decodeAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                    string[] usernamepassword = decodeAuthToken.Split(':');
                    string username = usernamepassword[0];
                    string password = usernamepassword[1];

                    if (ValidateUser.Login(username, password))
                    {
                        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username), null);
                    }
                    else
                    {
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Failed");
                    }
                }
                catch (Exception)
                {
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Internal Server Error - Login Failed");
                }
               
            }
        }
        public override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
        {
            return base.OnAuthorizationAsync(actionContext, cancellationToken);
        }
    }
}