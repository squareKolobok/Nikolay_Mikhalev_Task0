namespace FinalProject.Controllers
{
    using Infrostructure;
    using System;
    using System.Web.Mvc;

    public abstract class AbstractController<TIdenty> : Controller
          where TIdenty : MyIdentity
    {
        protected AbstractController()
        {
            _user = new Lazy<TIdenty>(() => HttpContext.User.Identity as TIdenty);
        }

        private readonly Lazy<TIdenty> _user;


        protected TIdenty CurrentUser { get { return _user.Value; } }
    }
}