using SociumApp.Data.Contracts;
using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Services
{
    public class UserService
    {
        private IEfSociumDataProvider provider;

        public UserService(IEfSociumDataProvider provider)
        {
            this.provider = provider;
        }

        public List<Question> GetMyQuestions(string username)
        {
            return this.provider.FindUserByUsername(username).MyQuestions.ToList();
        }

        public List<Vote> GetMyVotes(string username)
        {
            return this.provider.FindUserByUsername(username).MyVotes.ToList();
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
