using SociumApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Data.Contracts
{
    public interface IEfSociumDataProvider : IEfUnitOfWork
    {
        IEfRepository<Question> Questions { get;  }

        IEfRepository<Option> Options { get;  }

        IEfRepository<ApplicationUser> Users { get;  }

        IEfRepository<Vote> Votes { get;  }
    }
}
