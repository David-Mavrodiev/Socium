using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using SociumApp.Areas.Profile.Models;
using SociumApp.Identity;
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
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var model = new IndexViewModel
            {
                Username = username
            };
            return View(model);
        }
    }
}