using SociumApp.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Services.Contracts
{
    public interface IAdminService
    {
        int GetAllUsersCount();

        int GetAllQuestionsCount();

        int GetAllOptionsCount();

        int GetAllVotesCount();

        IEfSociumDataProvider GetProvider
        {
            get;
        }
    }
}
