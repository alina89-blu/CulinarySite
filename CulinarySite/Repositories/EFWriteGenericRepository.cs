using Microsoft.EntityFrameworkCore;
using Database;


namespace Repositories
{
    public class EFWriteGenericRepository<TEntity> : IWriteGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationContext db;
        private readonly DbSet<TEntity> dbSet;
        public EFWriteGenericRepository(ApplicationContext db)
        {
            this.db = db;
            this.dbSet = db.Set<TEntity>();
        }

        public void Create(TEntity item)
        {
            this.dbSet.Add(item);
        }

        public void Update(TEntity item)
        {
            this.db.Entry(item).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            TEntity item = dbSet.Find(id);
            if (item != null)
            {
                this.dbSet.Remove(item);
            }
        }

        public void Save()
        {
            this.db.SaveChanges();
        }
    }
}
