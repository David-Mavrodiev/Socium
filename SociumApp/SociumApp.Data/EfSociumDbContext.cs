using SociumApp.Data.Contracts;
using SociumApp.Models;
using SociumApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Data
{
    public class EfSociumDbContext : DbContext, ISociumDbContext
    {
        public EfSociumDbContext() : base("SociumAppLocal")
        {

        }

        public virtual IDbSet<Question> Categories { get; set; }

        public virtual IDbSet<Option> Products { get; set; }

        public IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IEfModel
        {
            return base.Set<TEntity>();
        }
    }
}
