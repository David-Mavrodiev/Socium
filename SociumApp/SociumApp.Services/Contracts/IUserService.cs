using SociumApp.Data.Contracts;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Services.Contracts
{
    public interface IUserService
    {
        List<Question> GetMyQuestions(string username);

        List<Vote> GetMyVotes(string username);

        IEfSociumDataProvider GetProvider
        {
            get;
        }
    }
}
