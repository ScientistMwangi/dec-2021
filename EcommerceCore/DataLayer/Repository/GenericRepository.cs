using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace EcommerceCore.DataLayer.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        // Find
        TEntity GetById(int id);
        TEntity Get(string id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity FindEntity(Expression<Func<TEntity, bool>> predicate);

        // Add
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);

        // update
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);

        // Remove
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
    }
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly EcommerceDbContext _Context;

        public GenericRepository(EcommerceDbContext Context)
        {
            _Context = Context;
        }

        public void Add(TEntity entity)
        {
            _Context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            _Context.Set<TEntity>().Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().UpdateRange(entities);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().AddRange(entities);
        }

        // Should return IEnumerable dont want users to add queries everywhere out of here
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().Where(predicate);
        }

        public TEntity FindEntity(Expression<Func<TEntity, bool>> predicate)
        {
            return _Context.Set<TEntity>().Where(predicate)?.FirstOrDefault();
        }

        public TEntity GetById(int id)
        {
            return _Context.Set<TEntity>().Find(id);
        }

        public TEntity Get(string id)
        {
            return _Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {

            return _Context.Set<TEntity>().ToList();

        }

        public void Remove(TEntity entity)
        {
            _Context.Set<TEntity>().Remove(entity);
            _Context.SaveChanges();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _Context.Set<TEntity>().RemoveRange(entities);
            _Context.SaveChanges();
        }
    }
}
