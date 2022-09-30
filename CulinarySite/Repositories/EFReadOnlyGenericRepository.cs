using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class EFReadOnlyGenericRepository<TEntity> : IReadOnlyGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationContext _db;
        private readonly DbSet<TEntity> _dbSet;
        public EFReadOnlyGenericRepository(ApplicationContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetItemList()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> GetItemListWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public TEntity GetItem(int id)
        {
            return _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public TEntity GetItemWithInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).Where(predicate).FirstOrDefault();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }

        public int GetNumberOfItems()
        {
            return _dbSet.Count();
        }
    }
}
