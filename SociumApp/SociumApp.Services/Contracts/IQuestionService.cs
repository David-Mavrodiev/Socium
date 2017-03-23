using SociumApp.Data.Contracts;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Services.Contracts
{
    public interface IQuestionService
    {
        void Create(string title, string ownerId, string defaultOptionDesc);

        void AddOptionToQuestion(int id, string description, string ownerId);

        void AddVoteToOption(int questionId, int optionId, string userId);

        List<Question> GetAll();

        Question GetById(int id);

        IEfSociumDataProvider GetProvider
        {
            get;
        }
    }
}
