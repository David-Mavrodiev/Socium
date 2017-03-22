using PagedList;
using SociumApp.Areas.Admin.Models;
using SociumApp.Models;
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
        public const int itemsPerPage = 10;
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

        public ActionResult UsersStatistic(int? page)
        {
            int pageNumber = page ?? 1;
            List<ApplicationUser> users = this.Service.GetProvider.Users.GetAll().ToList();
            return View(users.ToPagedList(pageNumber, itemsPerPage));
        }

        public ActionResult QuestionsStatistic(int? page)
        {
            int pageNumber = page ?? 1;
            List<Question> questions = this.Service.GetProvider.Questions.GetAll().ToList();
            return View(questions.ToPagedList(pageNumber, itemsPerPage));
        }

        public ActionResult OptionsStatistic(int? page)
        {
            int pageNumber = page ?? 1;
            List<Option> options = this.Service.GetProvider.Options.GetAll().ToList();
            return View(options.ToPagedList(pageNumber, itemsPerPage));
        }

        public ActionResult VotesStatistic(int? page)
        {
            int pageNumber = page ?? 1;
            List<Vote> votes = this.Service.GetProvider.Votes.GetAll().ToList();
            return View(votes.ToPagedList(pageNumber, itemsPerPage));
        }
    }
}