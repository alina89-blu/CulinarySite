﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Common.Exceptions;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace CulinarySite.Dal.Repositories
{
    public class EFReadOnlyGenericRepository<TEntity> : IReadOnlyGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly CulinarySiteDbContext _db;
        private readonly DbSet<TEntity> _dbSet;
        public EFReadOnlyGenericRepository(CulinarySiteDbContext db)
        {
            _db = db;
            _dbSet = db.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetItemList()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public IEnumerable<TEntity> GetItemListWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
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

        public int GetNumberOfItems()
        {
            return _dbSet.Count();
        }
    }
}