using GR.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace GR.Core.Repository
{
    public abstract class EntityRepository<TEntity, TContext> : IDTORepository<TEntity>,
        IEntityReadRepository<TEntity>, IEntityRepository<TEntity>, IDisposable
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly DbSet<TEntity> Entities;
        private bool _disposed;

        protected EntityRepository(TContext dbContext)
        {
            Entities = dbContext.Set<TEntity>();
        }

        protected void ThrowIfDisposed()
        {
            if (_disposed)
                throw new ObjectDisposedException(GetType().Name);
        }

        public void Dispose()
        {
            _disposed = true;
        }



        #region DTO Repository  
        public IEnumerable<TResult> DTOGetAll<TResult>(Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includes)
        {
            ThrowIfDisposed();
            var query = Entities.AsNoTracking();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return  query.Select(selector).ToList();
        }

        public IEnumerable<TResult> DTOGetBy<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includes)
        {
            ThrowIfDisposed();
            var query = Entities.AsNoTracking();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return  query.Where(filter).Select(selector).ToList();
        }

        public TResult DTOGetSingleBy<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, params Expression<Func<TEntity, object>>[] includes)
        {
            ThrowIfDisposed();
            var query = Entities.AsNoTracking();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.Where(filter).Select(selector).FirstOrDefault();
        }



        #endregion

        #region Read Repository
        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
            ThrowIfDisposed();
            return Entities.AsNoTracking().Any(filter);
        }

        public IEnumerable<TEntity> GetLAll(params Expression<Func<TEntity, object>>[] includes)
        {
            ThrowIfDisposed();
            var query = Entities.AsNoTracking();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return  query.ToList();
        }

        public IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            ThrowIfDisposed();
            var query = Entities.AsNoTracking();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return query.Where(filter).ToList();
        }


        public TEntity GetSingleBy(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            ThrowIfDisposed();
            var query = Entities.AsNoTracking();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return  query.Where(filter).FirstOrDefault();
        }

        #endregion


        #region Entity Repository
        public void Add(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Edit(TEntity item)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity item)
        {
            throw new NotImplementedException();
        }

    

        #endregion


    }
}
