using Ninject;
using SociumApp.Data.Contracts;
using SociumApp.Models;
using SociumApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SociumApp.Helpers
{
    public class MapperHelper
    {
        private QuestionService service;
        
        public MapperHelper(QuestionService service)
        {
            this.service = service;
        }
        
        public QuestionViewModel MapQuestionToViewModel(Question q)
        {
            List<OptionViewModel> options = new List<OptionViewModel>();
            foreach (var o in q.Options)
            {
                OptionViewModel opt = new OptionViewModel()
                {
                    Id = o.Id,
                    Description = o.Description,
                    VotesCount = o.Votes.Count
                };
                options.Add(opt);
            }
            options = options.OrderByDescending(o => o.VotesCount).ToList();
            QuestionViewModel model = new QuestionViewModel()
            {
                Title = q.Title,
                Id = q.Id,
                OwnerUsername = q.Owner.UserName,
                Options = options
            };

            return model;
        }

        public List<QuestionViewModel> MapQuestionsToViewModel(List<Question> all)
        {
            List<QuestionViewModel> models = new List<QuestionViewModel>();

            foreach (var item in all)
            {
                List<OptionViewModel> options = new List<OptionViewModel>();
                foreach (var o in item.Options)
                {
                    OptionViewModel opt = new OptionViewModel()
                    {
                        Id = o.Id,
                        Description = o.Description,
                        VotesCount = o.Votes.Count
                    };
                    options.Add(opt);
                }
                QuestionViewModel model = new QuestionViewModel()
                {
                    Id = item.Id,
                    Title = item.Title,
                    OwnerUsername = item.Owner.UserName,
                    Options = options
                };

                models.Add(model);
            }

            return models;
        }
    }
}