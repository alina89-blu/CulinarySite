using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Database;

namespace Repositories
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
