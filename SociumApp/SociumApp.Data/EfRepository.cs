using SociumApp.Data.Contracts;
using SociumApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Data
{
    public class EfRepository<TEntity> : IEfRepository<TEntity> where TEntity : class, IEfModel
    {
        private IDbSet<TEntity> dbSet;
        private IEfSociumDbContext dbContext;

        public EfRepository(IEfSociumDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = this.dbContext.GetDbSet<TEntity>();
        }

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public IQueryable<TEntity> GetAll()
        {
            return this.dbSet.AsQueryable();
        }

        public TEntity GetBy(params object[] properties)
        {
            return this.dbSet.Find(properties);
        }

        public void Remove(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> FindByExp(Expression<Func<TEntity, bool>> filterExpression)
        {
            return this.dbSet.Where(filterExpression);
        }
    }
}
