namespace FinalProject.Controllers
{
    using System.Web.Mvc;
    using DAL;
    using DAL.Models;
    using App_Start;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using Models;
    using Infrostructure;

    public class TestsController : Controller
    {
        private static Test test;
        private static List<ShareResultTest> shareTestResult;
        private static int i = -1;
        private static DateTime StartTime;
        private static Test newTest;
        private static List<Question> questions;

        private string connectionString = ConnectionStr.String;

        [AllowAnonymous]
        public ActionResult SelectTest(int id)
        {
            TestDAL dal = new TestDAL(connectionString);
            test = dal.GetTest(id);
            return View(test);
        }

        [Authorize]
        [HttpGet]
        public ActionResult StartTest()
        {
            i = 0;
            shareTestResult = new List<ShareResultTest>();
            StartTime = DateTime.Now;
            return View(test.Questions[i]);
        }

        [Authorize]
        [HttpPost]
        public ActionResult StartTest(List<int> Answer)
        {
            var TrueAnswers = test.Questions[i].Answers.Where(x => x.IsRight == true).Select(x => x.AnswerID).ToList();
            var isRight = true;

            foreach (int x in Answer)
            {
                isRight = isRight && (TrueAnswers.IndexOf(x) != -1);
            }

            ShareResultTest res = new ShareResultTest(test.Questions[i].QuestionID, isRight);
            shareTestResult.Add(res);
            i = test.Questions.Count - 1 >= i ? i + 1 : i;

            if (i != test.Questions.Count)
                return View(test.Questions[i]);
            else
                return RedirectToAction("EndTest");
        }

        [Authorize]
        public ActionResult EndTest()
        {
            int Count = 0;

            foreach (ShareResultTest x in shareTestResult)
            {
                Count += x.TrueAnswer ? 1 : 0;
            }

            int time = (int)(DateTime.Now - StartTime).TotalSeconds;
            ResultTest resultTest = new ResultTest(test.TestID, Count, time);
            TestDAL dal = new TestDAL(connectionString);
            dal.WriteResult(User.Identity.Name, resultTest, shareTestResult);
            test = null;
            shareTestResult = null;
            i = -1;
            StartTime = DateTime.MinValue;

            return View(resultTest);
        }

        [Authorize]
        public ActionResult TestResult()
        {
            TestDAL dal = new TestDAL(connectionString);
            var result = dal.GetResultTests(User.Identity.Name);

            return View(result);
        }

        [Auth(Roles = "Moderator")]
        public ActionResult ShareResult(string id, string User)
        {
            int idTest;

            if (!int.TryParse(id, out idTest) || User == null)
            {
                return RedirectToAction("SearchShareResult", "Home");
            }

            TestDAL dal = new TestDAL(connectionString);
            var shareResult = dal.GetShareResultTest(User, idTest);
            var test = dal.GetTest(idTest);
            var res = from x in shareResult
                      join y in test.Questions
                      on x.QuestionID
                      equals y.QuestionID
                      select new ShareRes
                      {
                          Text = y.QuestionText,
                          IsRight = x.TrueAnswer
                      };

            return View(res);
        }

        [Auth(Roles = "Moderator")]
        public ActionResult SelectCreateTest()
        {
            return View();
        }

        [Auth(Roles = "Moderator")]
        [HttpGet]
        public ActionResult CreateTest(string NameTest, string Time)
        {
            int time = 1;

            if (!int.TryParse(Time, out time))
            {
                return RedirectToAction("SelectCreateTest");
            }

            newTest = new Test(1, NameTest, time * 60);
            questions = new List<Question>();
            return View();
        }

        [Auth(Roles = "Moderator")]
        [HttpPost]
        public ActionResult CreateTest(string QuestionText, List<string> AnswerText, List<int> IsRight, TypeQuestion TypeQuestion)
        {
            List<Answer> ans = new List<Answer>();

            for (int i =0; i < AnswerText.Count; i++)
            {
                ans.Add(new Answer(AnswerText[i], IsRight.IndexOf(i) != -1 ));
            }

            Question quest = new Question(1, QuestionText, null, TypeQuestion, ans);
            questions.Add(quest);
            return View();
        }

        [Auth(Roles = "Moderator")]
        [HttpPost]
        public ActionResult EndCreateTest(string QuestionText, List<string> AnswerText, List<int> IsRight, TypeQuestion TypeQuestion)
        {

            List<Answer> ans = new List<Answer>();

            for (int i = 0; i < AnswerText.Count; i++)
            {
                ans.Add(new Answer(AnswerText[i], IsRight.IndexOf(i) != -1));
            }

            Question quest = new Question(1, QuestionText, null, TypeQuestion, ans);
            questions.Add(quest);

            Test test = new Test(newTest.TestID, newTest.NameTest, newTest.Time,User.Identity.Name,DateTime.Now, questions);
            TestDAL dal = new TestDAL(connectionString);
            dal.CreateTest(test, User.Identity.Name);

            return View(test);
        }

        [Auth(Roles = "Moderator")]
        public ActionResult SelectDeleteTest()
        {
            List<Test> result = new List<Test>();
            TestDAL dal = new TestDAL(connectionString);
            result = dal.SearchTest(String.Empty).Where(x => x.User.Equals(User.Identity.Name)).ToList();

            return View(result);
        }

        [Auth(Roles = "Moderator")]
        public ActionResult DeleteTest(int id)
        {
            TestDAL dal = new TestDAL(connectionString);
            dal.DeleteTest(id);

            return RedirectToAction("SelectDeleteTest");
        }
    }
}