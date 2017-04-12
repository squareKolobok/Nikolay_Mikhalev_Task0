namespace FinalProject.Infrostructure
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Security;

    public class AuthAttribute : AuthorizeAttribute
    {
        private string[] allowedRoles = new string[] { };

        public AuthAttribute()
        {
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            if (!filterContext.IsChildAction)
                filterContext.Result = new RedirectResult("/");
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            if (!String.IsNullOrEmpty(base.Roles))
            {
                allowedRoles = base.Roles.Split(new char[] { ',' });
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    allowedRoles[i] = allowedRoles[i].Trim();
                }
            }

            return httpContext.Request.IsAuthenticated && Role(httpContext);
        }

        private bool Role(HttpContextBase httpContext)
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            var cookie = httpContext.Request.Cookies[cookieName.ToUpper()];
            var ticket = FormsAuthentication.Decrypt(cookie.Value);
            string roles = ticket.UserData;

            if (allowedRoles.Length > 0)
            {
                for (int i = 0; i < allowedRoles.Length; i++)
                {
                    if (roles.IndexOf(allowedRoles[i]) != -1)
                        return true;
                }
                return false;
            }
            return true;
        }
    }
}