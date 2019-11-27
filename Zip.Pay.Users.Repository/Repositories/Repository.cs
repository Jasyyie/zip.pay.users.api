using Zip.Pay.Users.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Zip.Pay.Users.Repository.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        protected DbSet<TEntity> DbSet { get; set; }
        private readonly ZipPayUserDbContext _dbContext;

        public Repository(ZipPayUserDbContext dbContext)
        {
            _dbContext = dbContext;
            DbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task<IQueryable<TEntity>> GetAll()
        {
            return await Task.Run(() => DbSet.AsQueryable());
        }

        public virtual async Task<IQueryable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() =>
            {
                var result = DbSet.Where(predicate).AsQueryable();
                return result;
            });
        }
        public virtual async Task Add(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
