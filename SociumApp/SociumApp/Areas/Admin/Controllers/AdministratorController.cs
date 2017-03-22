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

        public ActionResult UsersStatistic(int? page, int? sortingCode)
        {
            int pageNumber = page ?? 1;
            List<ApplicationUser> users = this.Service.GetProvider.Users.GetAll().ToList();

            if (sortingCode == 0)
            {
                users = this.Service.GetProvider.Users.GetAll().ToList().OrderByDescending(u => u.UserName).ToList();
            }
            else if (sortingCode == 1)
            {
                users = this.Service.GetProvider.Users.GetAll().ToList().OrderByDescending(u => u.MyQuestions.Count).ToList();
            }
            else if (sortingCode == 2)
            {
                users = this.Service.GetProvider.Users.GetAll().ToList().OrderByDescending(u => u.MyVotes.Count).ToList();
            }
            return View(users.ToPagedList(pageNumber, itemsPerPage));
        }

        public ActionResult QuestionsStatistic(int? page, int? sortingCode)
        {
            int pageNumber = page ?? 1;
            List<Question> questions = this.Service.GetProvider.Questions.GetAll().ToList();

            if (sortingCode == 0)
            {
                questions = this.Service.GetProvider.Questions.GetAll().ToList().OrderByDescending(q => q.Title).ToList();
            }
            else if (sortingCode == 1)
            {
                questions = this.Service.GetProvider.Questions.GetAll().ToList().OrderByDescending(q => q.Owner.UserName).ToList();
            }
            else if (sortingCode == 2)
            {
                questions = this.Service.GetProvider.Questions.GetAll().ToList().OrderByDescending(q => q.Options.Count).ToList();
            }
            return View(questions.ToPagedList(pageNumber, itemsPerPage));
        }

        public ActionResult OptionsStatistic(int? page, int? sortingCode)
        {
            int pageNumber = page ?? 1;
            List<Option> options = this.Service.GetProvider.Options.GetAll().ToList();

            if (sortingCode == 0)
            {
                options = this.Service.GetProvider.Options.GetAll().ToList().OrderByDescending(o => o.Description).ToList();
            }
            else if (sortingCode == 1)
            {
                options = this.Service.GetProvider.Options.GetAll().ToList().OrderByDescending(o => o.Owner.UserName).ToList();
            }
            else if (sortingCode == 2)
            {
                options = this.Service.GetProvider.Options.GetAll().ToList().OrderByDescending(o => o.Question.Title).ToList();
            }
            else if (sortingCode == 3)
            {
                options = this.Service.GetProvider.Options.GetAll().ToList().OrderByDescending(o => o.Votes.Count).ToList();
            }
            return View(options.ToPagedList(pageNumber, itemsPerPage));
        }

        public ActionResult VotesStatistic(int? page, int? sortingCode)
        {
            int pageNumber = page ?? 1;
            List<Vote> votes = this.Service.GetProvider.Votes.GetAll().ToList();
            if (sortingCode == 0)
            {
                votes = this.Service.GetProvider.Votes.GetAll().ToList().OrderByDescending(v => v.Option.Description).ToList();
            }
            else if (sortingCode == 1)
            {
                votes = this.Service.GetProvider.Votes.GetAll().ToList().OrderByDescending(v => v.Owner.UserName).ToList();
            }
            else if (sortingCode == 2)
            {
                votes = this.Service.GetProvider.Votes.GetAll().ToList().OrderByDescending(v => v.Question.Title).ToList();
            }

            return View(votes.ToPagedList(pageNumber, itemsPerPage));
        }
    }
}