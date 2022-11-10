using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CulinarySite.Common.Exceptions;
using CulinarySite.Common.Pagination;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CulinarySite.Dal.Repositories
{
    public class EFReadOnlyGenericRepository<TEntity> : IReadOnlyGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        public EFReadOnlyGenericRepository(CulinarySiteDbContext db)
        {
            _dbSet = db.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetItemList()
        {
            // return _dbSet.AsNoTracking().ToList();
            return _dbSet.AsNoTracking();
        }

        public IEnumerable<TEntity> GetItemListWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IQueryable<TEntity> GetItemListQueryableWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties);
        }

        public TEntity GetItem(int id)
        {
            TEntity item = _dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                throw new NotFoundException($"Object of type {typeof(TEntity)} with id { id } not found");
            }

            return item;
        }

        public TEntity GetItemWithInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            TEntity item = Include(includeProperties).Where(predicate).FirstOrDefault();

            if (item == null)
            {
                throw new NotFoundException($"Object of type {typeof(TEntity)} not found");
            }

            return item;
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
     
        public PagedList<TEntity> GetPagedItems(IQueryable<TEntity> query, PagingParameters pagingParameters, Dictionary<string, Expression<Func<TEntity, object>>> orderMappings)
        {
            if (pagingParameters.ActiveColumn != null && orderMappings.ContainsKey(pagingParameters.ActiveColumn))
            {
                if (pagingParameters.IsAscending)
                {
                    query = query.OrderBy(orderMappings[pagingParameters.ActiveColumn]);
                }
                else
                {
                    query = query.OrderByDescending(orderMappings[pagingParameters.ActiveColumn]);
                }
            }

            return new PagedList<TEntity>(query, pagingParameters);
        }

    }
}
