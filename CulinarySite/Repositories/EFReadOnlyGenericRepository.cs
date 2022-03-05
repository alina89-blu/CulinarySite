using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Database;
using Microsoft.EntityFrameworkCore;

namespace Repositories
{
    public class EFReadOnlyGenericRepository<TEntity> : IReadOnlyGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationContext db;
        private readonly DbSet<TEntity> dbSet;
        public EFReadOnlyGenericRepository(ApplicationContext db)
        {
            this.db = db;
            this.dbSet = db.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetItemList()
        {
            return this.dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> GetItemListWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return this.Include(includeProperties).ToList();
        }

        public TEntity GetItem(int id)
        {
            return this.dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public TEntity GetItemWithInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return this.Include(includeProperties).Where(predicate).FirstOrDefault();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = this.dbSet.AsNoTracking();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
       
        public int GetNumberOfItems()
        {
            return this.dbSet.Count();
        }
    }
}
