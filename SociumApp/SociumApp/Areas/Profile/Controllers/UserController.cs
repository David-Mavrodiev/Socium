using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SociumApp.Areas.Profile.Models;
using SociumApp.Identity;
using SociumApp.Models;
using SociumApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SociumApp.Areas.Profile.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public UserController(UserService service)
        {
            this.Service = service;
        }

        public ActionResult Index()
        {
            var username = User.Identity.Name;
            List<Question> myQuestions = this.Service.GetMyQuestions(username);
            List<Vote> myVotes = this.Service.GetMyVotes(username);

            var model = new IndexViewModel
            {
                Username = username,
                MyQuestions = myQuestions,
                MyVotes = myVotes
            };

            return View(model);
        }

        public UserService Service { get; set; }
    }
}