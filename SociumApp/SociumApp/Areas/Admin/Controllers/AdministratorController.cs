using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SociumApp.Areas.Admin.Controllers
{
    public class AdministratorController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult UsersStatistic()
        {
            return View();
        }

        public ActionResult QuestionsStatistic()
        {
            return View();
        }

        public ActionResult OptionsStatistic()
        {
            return View();
        }

        public ActionResult VotesStatistic()
        {
            return View();
        }
    }
}