using SociumApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Data.Contracts
{
    public interface IEfSociumDbContext
    {
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IEfModel;

        int SaveChanges();
    }
}
