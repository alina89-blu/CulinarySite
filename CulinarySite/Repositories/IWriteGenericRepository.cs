using System;
using Database;

namespace Repositories
{
    public interface IWriteGenericRepository<TEntity> where TEntity : BaseEntity
    {
        void Create(TEntity item);
        void Update(TEntity item);
        void Delete(int id);
        void Save();

    }
   
}
