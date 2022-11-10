using Microsoft.EntityFrameworkCore;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using CulinarySite.Common.Exceptions;

namespace CulinarySite.Dal.Repositories
{
    public class EFWriteGenericRepository<TEntity> : IWriteGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly CulinarySiteDbContext _db;
        private readonly DbSet<TEntity> _dbSet;
        public EFWriteGenericRepository(CulinarySiteDbContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }

        public void Update(TEntity item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TEntity item = _dbSet.Find(id);

            if (item == null)
            {
                throw new NotFoundException($"Object of type {typeof(TEntity)} with id { id } not found");
            }

            _dbSet.Remove(item);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
