using SociumApp.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SociumApp.Data.Contracts
{
    public interface IEfRepository<TEntity> where TEntity : class, IEfModel
    {
        TEntity GetBy(params object[] properties);

        IQueryable<TEntity> GetAll(TEntity entity);

        void Add(TEntity entity);

        void Remove(TEntity entity);

        IEnumerable<TEntity> FindByExp(Expression<Func<TEntity, bool>> filterExpression);
    }
}
