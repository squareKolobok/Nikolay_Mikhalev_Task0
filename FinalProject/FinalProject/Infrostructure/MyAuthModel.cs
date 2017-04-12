namespace FinalProject.Infrostructure
{
    using System;
    using System.Security.Principal;
    using System.Threading;
    using System.Web;
    using System.Web.Security;

    public class MyAuthModel : IHttpModule
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += OnAuthenticateRequest;
        }

        private static void OnAuthenticateRequest(object sender, EventArgs e)
        {
            var application = (HttpApplication)sender;
            var context = application.Context;

            if (context.User != null && context.User.Identity.IsAuthenticated)
                return;

            var cookieName = FormsAuthentication.FormsCookieName;
            var cookie = application.Request.Cookies[cookieName.ToUpper()];

            if (cookie == null)
                return;

            try
            {
                var ticket = FormsAuthentication.Decrypt(cookie.Value);
                var identity = MyIdentity.Deserialize(ticket.UserData);
                var principal = new GenericPrincipal(identity, identity.Role);
                context.User = principal;
                Thread.CurrentPrincipal = principal;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}