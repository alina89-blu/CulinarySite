using CulinarySite.Common.Pagination;
using CulinarySite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CulinarySite.Dal.Interfaces
{
    public interface IReadOnlyGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetItemList();
        IEnumerable<TEntity> GetItemListWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        IQueryable<TEntity> GetItemListQueryableWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetItem(int id);
        TEntity GetItemWithInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        PagedList<TEntity> GetPagedItems(IQueryable<TEntity> query, PagingParameters pagingParameters, Dictionary<string, Expression<Func<TEntity, object>>> orderMappings);
    }
}
