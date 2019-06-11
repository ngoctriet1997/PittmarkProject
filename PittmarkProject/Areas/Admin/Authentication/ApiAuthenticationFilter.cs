using Pittmark.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace PittmarkProject.Areas.Admin.Authentication
{
    public class ApiAuthenticationFilter : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
           if(actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            else
            {
                DaoLogin daoLogin = new DaoLogin();
                string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
                string username = authenticationToken.Split(':')[0];
                string password = authenticationToken.Split(':')[1];
                string role = daoLogin.GetRole(username, password).ToString();
                if (int.Parse(role) == 1)
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(username),new string[] { role } );
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
        }
    }
}