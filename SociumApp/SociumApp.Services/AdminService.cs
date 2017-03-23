using SociumApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Services
{
    public class AdminService
    {
        private IEfSociumDataProvider provider;

        public AdminService(IEfSociumDataProvider provider)
        {
            this.provider = provider;
        }
        
        public int GetAllUsersCount()
        {
            return this.provider.Users.GetAll().ToList().Count;
        }

        public int GetAllQuestionsCount()
        {
            return this.provider.Questions.GetAll().ToList().Count;
        }

        public int GetAllOptionsCount()
        {
            return this.provider.Options.GetAll().ToList().Count;
        }

        public int GetAllVotesCount()
        {
            return this.provider.Votes.GetAll().ToList().Count;
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
