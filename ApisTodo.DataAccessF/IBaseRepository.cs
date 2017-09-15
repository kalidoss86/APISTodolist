using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace ApisTodo.DataAccessF
{
    public interface IBaseRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");

        Task<TEntity> GetById(object id);

        Task<TEntity> Add(TEntity entity);

        Task<bool> Delete(object id);

        Task<bool> Delete(TEntity entity);

        Task<bool> Update(TEntity entity);

    }
}
