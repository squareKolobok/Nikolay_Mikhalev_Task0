namespace FinalProject.Controllers
{
    using Models.Abstract;
    using System;
    using System.Web.Mvc;

    //TIdenty - Тип реализованого класса идентификации
    //TAccount -   Тип аккаунта в бизнес логике.
    //TRole - Тип роли.
    public abstract class AbstractController<TIdenty, TAccount, TRole> : Controller
          where TIdenty : AbstractIdentity<TAccount, TRole>
    {
        protected AbstractController()
        {
            _user = new Lazy<TIdenty>(() => HttpContext.User.Identity as TIdenty);
        }

        private readonly Lazy<TIdenty> _user;


        protected TIdenty CurrentUser { get { return _user.Value; } }
    }
}