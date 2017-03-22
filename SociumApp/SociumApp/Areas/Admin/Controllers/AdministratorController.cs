using SociumApp.Areas.Admin.Models;
using SociumApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SociumApp.Areas.Admin.Controllers
{
    public class AdministratorController : Controller
    {
        public AdministratorController(AdminService service)
        {
            this.Service = service;
        }
        
        public AdminService Service { get; set; }

        public ActionResult Index()
        {
            IndexAdminViewModel model = new IndexAdminViewModel()
            {
                 OptionsCount = this.Service.GetAllOptionsCount(),
                 QuestionsCount = this.Service.GetAllQuestionsCount(),
                 UsersCount = this.Service.GetAllUsersCount(),
                 VotesCount = this.Service.GetAllVotesCount()
            };

            return View(model);
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