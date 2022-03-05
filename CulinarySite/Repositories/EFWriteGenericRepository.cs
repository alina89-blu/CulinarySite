using Microsoft.EntityFrameworkCore;
using Database;
using System.Collections.Generic;
using System.Linq;


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

        public TEntity GetItem(int id)
        {
            // return this.dbSet.Find(id);
            return this.dbSet.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<TEntity> GetItemList()
        {
            return this.dbSet.ToList();
        }

    }
}
