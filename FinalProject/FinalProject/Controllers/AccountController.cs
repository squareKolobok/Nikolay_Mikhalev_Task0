namespace FinalProject.Controllers
{
    using DAL.Models;
    using DAL;
    using App_Start;
    using FinalProject.Models;
    using Infrostructure.Relase;
    using System.Web.Mvc;

    public class AccountController : AbstractController<ConcreteIdentity, Account, Role>
    {

        private string connectionString = ConnectionStr.String;

        private bool RangeLengthString(int start, int end, string str)
        {
            return str  != null && str.Length >= start && str.Length <= end;
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Registration(string Name, string passwd1, string passwd2)
        {

            if (!(RangeLengthString(3, 15, Name) && RangeLengthString(3,30,passwd1) && RangeLengthString(3, 30, passwd2)))
            {
                ViewBag.Message = "Выход за границу колличества символов";
                return View();
            }

            TestDAL dal = new TestDAL(connectionString);

            if (passwd1.Equals(passwd2) && !dal.ExistUser(Name))
            {
                dal.CreateUser(Name, passwd1);
                ViewBag.Message = "Пользователь создан";
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Message = passwd1.Equals(passwd2) ? "Пароли не совпадают" : "такой пользователь существует";
                return View();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(Login login)
        {
            TestDAL dal = new TestDAL(connectionString);
            Role roleUser;
            if (dal.IsRightLogPass(login.Name, login.Password, out roleUser))
            {
                var account = new Account()
                {
                    Login = login.Name,
                    Password = login.Password,
                    role = roleUser
                };
                var authorize = new ConcreteAuthorizeService();
                authorize.SignIn(account, false);
            }
            else
            {
                ViewBag.Message = "Логин или пароль введен неверно";
                return View();
            }
            return RedirectToAction("Welcome");
        }

        [Authorize]
        //[ConcreteAuthintification]
        public ActionResult Welcome()
        {
            return View();
        }

        [Authorize]
        public ActionResult Logout()
        {
            var authorize = new ConcreteAuthorizeService();
            authorize.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(string OldPassword, string NewPassword1, string NewPassword2)
        {
            if (!(RangeLengthString(3, 30, OldPassword) && RangeLengthString(3, 30, NewPassword1) && RangeLengthString(3, 30, NewPassword2)))
            {
                ViewBag.Message = "Выход за границу колличества символов";

                return View();
            }

            if (NewPassword1.Equals(NewPassword2))
            {
                TestDAL dal = new TestDAL(connectionString);
                ViewBag.Message = dal.ChangePassword(User.Identity.Name, OldPassword, NewPassword1) ?
                    "Пароль изменен" : "Пароль введен неверно";

                return View();
            }
            else
            {
                ViewBag.Message = "Пароли не совпадают";

                return View();
            }
        }
    }
}