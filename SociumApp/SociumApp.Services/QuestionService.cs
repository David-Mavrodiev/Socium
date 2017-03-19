using SociumApp.Data;
using SociumApp.Data.Contracts;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Services
{
    public class QuestionService
    {
        public IEfSociumDataProvider provider;

        public QuestionService(IEfSociumDataProvider provider)
        {
            this.provider = provider;
        }

        public void Create(string title, string ownerId, string defaultOptionDesc)
        {
            Question question = new Question()
            {
                Title = title,
                OwnerId = ownerId
            };
            question.Options.Add(new Option()
            {
                  Description = defaultOptionDesc
            });
            this.provider.Questions.Add(question);
            this.provider.Commit();
        }

        public void AddOptionToQuestion(int id, string description)
        {
            Question question = this.GetById(id);

            question.Options.Add(new Option()
            {
                Description = description
            });

            this.provider.Commit();
        }

        public List<Question> GetAll()
        {
            return this.provider.Questions.GetAll().ToList();
        }

        public Question GetById(int id)
        {
            return this.provider.Questions.GetBy(id);
        }

        public IEfSociumDataProvider GetProvider
        {
            get
            {
                return this.provider;
            }
        }
    }
}
