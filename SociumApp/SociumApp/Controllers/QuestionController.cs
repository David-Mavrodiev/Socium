using Microsoft.AspNet.Identity.Owin;
using SociumApp.Data;
using SociumApp.Data.Contracts;
using SociumApp.Helpers;
using SociumApp.Identity;
using SociumApp.Models;
using SociumApp.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SociumApp.Controllers
{
    public class QuestionController : Controller
    {
        public QuestionController(QuestionService service, MapperHelper helper)
        {
            this.Service = service;
            this.Helper = helper;
        }

        public QuestionService Service { get; private set; }

        public MapperHelper Helper { get; set; }

        public ActionResult Index()
        {
            var all = this.Service.GetAll();
            return View(this.Helper.MapQuestionsToViewModel(all));
        }

        [HttpPost]
        public async Task<ActionResult> Create(string DefaultOptionDesc, QuestionViewModel model)
        {
            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = await manager.FindByNameAsync(User.Identity.Name);
            this.Service.Create(model.Title, user.Id, DefaultOptionDesc);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetDetailed(int id)
        {
            Question question = this.Service.GetById(id);
            return View(this.Helper.MapQuestionToViewModel(question));
        }

        [HttpPost]
        public JsonResult AddOption(string description, int id)
        {
            this.Service.AddOptionToQuestion(id, description);
            return Json("success");
        }

        [HttpPost]
        public JsonResult AddVote(int id, int optionId)
        {
            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = this.Service.GetProvider.Users.FindByExp(u => u.UserName == User.Identity.Name).SingleOrDefault();
            this.Service.AddVoteToOption(id, optionId, user.Id);
            return Json("success");
        }
    }
}