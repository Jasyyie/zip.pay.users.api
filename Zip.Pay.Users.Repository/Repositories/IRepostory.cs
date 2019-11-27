using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Zip.Pay.Users.Repository.Repositories
{
    public interface IRepository<TEntity>
    {
        Task<IQueryable<TEntity>> GetAll();
        Task<IQueryable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate);
        Task Add(TEntity entity);
    }
}