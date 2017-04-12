using DAL;
using DAL.Models;
using FinalProject.App_Start;
using FinalProject.Infrostructure;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FinalProject.Controllers
{
    public class HomeController : Controller
    {

        private string connectionString = ConnectionStr.String;

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult SearchTest(string NameTest)
        {
            List<Test> result = new List<Test>();

            if (NameTest != null)
            {
                TestDAL dal = new TestDAL(connectionString);
                result = dal.SearchTest(NameTest);
            }

            return View(result);
        }

        [AllowAnonymous]
        [Auth (Roles = "Moderator")]
        public ActionResult SearchShareResult()
        {
            TestDAL dal = new TestDAL(connectionString);
            var result = dal.SearchTest(string.Empty);
            return View(result);
        }

        [HttpGet]
        [Auth (Roles = "Administrator")]
        public ActionResult ChangeAccess()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [Auth(Roles = "Administrator")]
        public ActionResult ChangeAccess(Role newRole, string Name)
        {
            TestDAL dal = new TestDAL(connectionString);
            bool res = dal.ChangeStatus(User.Identity.Name, Name, newRole);
            ViewBag.Message = res ? "Пользователь получил другую роль" : "Не получилось дать пользователю другую роль";

            return View();
        }
    }
}