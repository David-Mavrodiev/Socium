using Microsoft.AspNet.Identity.Owin;
using SociumApp.Data;
using SociumApp.Data.Contracts;
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
        public QuestionController(QuestionService service)
        {
            this.Service = service;
        }

        public IEfSociumDbContext DbContext { get; set; }

        public QuestionService Service { get; private set; }

        public ActionResult Index()
        {
            var all = this.Service.GetAll();
            List<QuestionViewModel> models = new List<QuestionViewModel>();
            foreach (var item in all)
            {
                QuestionViewModel model = new QuestionViewModel()
                {
                    Title = item.Title,
                    OwnerUsername = Service.GetProvider.Users.GetBy(item.OwnerId).UserName
                };

                models.Add(model);
            }

            return View(models);
        }

        [HttpPost]
        public async Task<ActionResult> Create(QuestionViewModel model)
        {
            var manager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var user = await manager.FindByNameAsync(User.Identity.Name);
            this.Service.Create(model.Title, user.Id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
    }
}