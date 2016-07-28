using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace genericRepositoryUnitOfWork.Repository
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal DbContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(DbContext dbContext)
        {
            _context = dbContext;
            _dbSet = _context.Set<TEntity>();
        }
  
        // Get all
        public IEnumerable<TEntity> GetAll()
        {
            try
            {
                IEnumerable<TEntity> allEntities = _dbSet;
                return _dbSet;
            }
            catch (Exception ex)
            {
                // logging                
                throw ex;
            }
        }

        // Get by primary key
        public TEntity GetByPrimaryKey(object primaryKey)
        {
            try
            {
                TEntity entity = _dbSet.Find(primaryKey);
                return entity;
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
        }

        // Insert
        public TEntity Insert(TEntity entity)
        {
            try
            {
                TEntity addedEntity = _dbSet.Add(entity);
                return addedEntity;
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
        }

        // Update
        public TEntity Update(TEntity entity)
        {
            try
            {
                TEntity updatedEntity = _dbSet.Attach(entity);
                _context.Entry(updatedEntity).State = EntityState.Modified;
                return updatedEntity;
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
        }

        // Delete
        public TEntity Delete(object primaryKey)
        {
            try
            {
                TEntity entityToDelete = _dbSet.Find(primaryKey);
                entityToDelete = _dbSet.Remove(entityToDelete);                
                return entityToDelete;
            }
            catch (Exception ex)
            {
                // logging
                throw ex;
            }
        }
    }
}
