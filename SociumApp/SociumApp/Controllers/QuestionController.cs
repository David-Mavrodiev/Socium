﻿using Microsoft.AspNet.Identity.Owin;
using SociumApp.Data;
using SociumApp.Data.Contracts;
using SociumApp.Helpers;
using SociumApp.Identity;
using SociumApp.Models;
using SociumApp.Services;
using SociumApp.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SociumApp.Controllers
{
    public class QuestionController : Controller
    {
        public QuestionController(IQuestionService service, MapperHelper helper)
        {
            this.Service = service;
            this.Helper = helper;
        }

        public IQuestionService Service { get; private set; }

        public MapperHelper Helper { get; set; }

        public ActionResult Index()
        {
            var all = this.Service.GetAll();
            return View(this.Helper.MapQuestionsToViewModel(all));
        }

        [HttpPost]
        [ValidateInput(enableValidation:false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string DefaultOptionDesc, QuestionViewModel model)
        {
            var user = this.Service.GetProvider.FindUserByUsername(User.Identity.Name);
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
        [ValidateInput(enableValidation: false)]
        public JsonResult AddOption(string description, int id)
        {
            var user = this.Service.GetProvider.FindUserByUsername(User.Identity.Name);
            this.Service.AddOptionToQuestion(id, description, user.Id);
            return Json("success");
        }

        [HttpPost]
        public JsonResult AddVote(int id, int optionId)
        {
            var user = this.Service.GetProvider.FindUserByUsername(User.Identity.Name);
            bool IsVoted = false;
            foreach (var item in user.MyVotes)
            {
                if (item.QuestionId == id)
                {
                    IsVoted = true;
                }
            }
            if (!IsVoted)
            {
                this.Service.AddVoteToOption(id, optionId, user.Id);
                return Json("success");
            }
            else
            {
                return Json("error");
            }
            
        }

        [HttpPost]
        public JsonResult CheckVote(int id)
        {
            var user = this.Service.GetProvider.FindUserByUsername(User.Identity.Name);
            foreach (var item in user.MyVotes)
            {
                if (item.QuestionId == id)
                {
                    return Json("Yes");
                }   
            }
            return Json("No");
        }

        [HttpPost]
        public JsonResult CheckOption(int id)
        {
            var question = this.Service.GetProvider.Questions.GetBy(id);

            foreach (var item in question.Options)
            {
                if (item.Owner.UserName == User.Identity.Name)
                {
                    return Json("Yes");
                }
            }
            return Json("No");
        }
    }
}