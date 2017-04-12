namespace FinalProject.Infrostructure
{
    using System;
    using FinalProject.Models;
    using System.Web.Security;
    using System.Web;
    using System.Security.Principal;
    using System.Text;

    public class Auth : IAuth<Account>
    {
        private const int TICKET_VERSION = 1;
        private const int EXPIRATION_MINUTE = 60;

        public void Login(Account account)
        {
            MyIdentity myIdentity = new MyIdentity();
            myIdentity.Init(account);

            var ticket = new FormsAuthenticationTicket(
                  1,
                  myIdentity.Name,
                  DateTime.Now,
                  DateTime.Now.Add(FormsAuthentication.Timeout),
                  false,
                  ArrToString(myIdentity.Role),
                  FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket))
            {
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout),
            };

            HttpContext.Current.Response.Cookies.Add(authCookie);
            HttpContext.Current.User = new GenericPrincipal(myIdentity, myIdentity.Role);
        }

        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        private string ArrToString(string[] arr)
        {
            StringBuilder str = new StringBuilder();

            foreach (string x in arr)
            {
                str.Append(x);
                str.Append(" ");
            }

            return str.ToString();
        }
    }
}