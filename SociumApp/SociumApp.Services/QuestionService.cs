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

        public void Create(string title, string ownerId)
        {
            Question question = new Question()
            {
                Title = title,
                OwnerId = ownerId
            };

            this.provider.Questions.Add(question);
            this.provider.Commit();
        }

        public List<Question> GetAll()
        {
            return this.provider.Questions.GetAll().ToList();
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
