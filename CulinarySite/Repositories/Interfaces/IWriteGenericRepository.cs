using CulinarySite.Domain.Entities;
using System.Collections.Generic;

namespace CulinarySite.Dal.Interfaces
{
    public interface IWriteGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
        void Save();
        TEntity GetItem(int id);
        IEnumerable<TEntity> GetItemList();
    }
}
