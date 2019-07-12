using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace DemoApi.Filters
{
    public class BasicAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            try
            {
                if (actionContext.Request.Headers.Authorization == null)
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);

                string basicAuthToken = actionContext.Request.Headers.Authorization.Parameter;

                string decodedToken = Encoding.UTF8.GetString(Convert.FromBase64String(basicAuthToken));
                string[] authArray = decodedToken.Split(':');
                string userName = authArray[0];
                string password = authArray[1];

                //check security

                if (ValidateUser(userName, password))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), new string[] { "UserRole" });
                }
                else
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
            }
            catch
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
        }

        private bool ValidateUser(string userName, string password)
        {
            List<string> userList = new List<string> { "jani", "vitor", "andrew" };

            if (string.IsNullOrEmpty(userName))
                return false;

            if (userList.Contains(userName))
                return true;

            return false;
        }
        //Do not delete before implementation, sample code
        //loginhelper is in roles
        //public static bool IsInRoles(params string[] roleNames)
        //{
        //    var user = GetLoggedInUserFromSession();
        //    return user.UserRoles.Any(r => roleNames.Select(n => n.ToLower()).Contains(r.Role.Name.ToLower()));
        //}
    }
}