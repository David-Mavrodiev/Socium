using SociumApp.Data;
using SociumApp.Data.Contracts;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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
            Question question = new Question();
            question.Title = title;
            question.OwnerId = ownerId;
            this.provider.Questions.Add(question);
            this.provider.Commit();

            var savedQuestion = this.provider.FindQuestionByTitle(title);
            savedQuestion.Options.Add(new Option()
            {
                Description = defaultOptionDesc,
                Id = savedQuestion.Id,
                OwnerId = ownerId
            });

            this.provider.Commit();
        }

        public void AddOptionToQuestion(int id, string description, string ownerId)
        {
            Question question = this.GetById(id);

            question.Options.Add(new Option()
            {
                Description = description,
                QuestionId = question.Id,
                OwnerId = ownerId
                 
            });

            this.provider.Commit();
        }

        public void AddVoteToOption(int questionId, int optionId, string userId)
        {
            var option = this.provider.Options.GetBy(optionId);
            option.Votes.Add(new Vote()
            {                 
               OwnerId = userId,
               OptionId = option.Id,
               QuestionId = questionId
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
