using CulinarySite.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;


namespace CulinarySite.Dal.Interfaces
{
    public interface IReadOnlyGenericRepository<TEntity> where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetItemList();
        IEnumerable<TEntity> GetItemListWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        TEntity GetItem(int id);
        TEntity GetItemWithInclude(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        int GetNumberOfItems();

    }
}
