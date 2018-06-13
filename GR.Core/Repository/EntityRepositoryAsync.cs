using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GR.Core.Interface;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Threading;
using System.Linq;

namespace GR.Core.Repository
{
    public abstract class EntityRepositoryAsync<TEntity, TContext> : IDTORepositoryAsync<TEntity>,
      IEntityReadRepositoryAsync<TEntity>, IEntityRepositoryAsync<TEntity>, IDisposable
      where TEntity : class, IEntity
      where TContext : DbContext
    {
        protected readonly DbSet<TEntity> Entities;
        private bool _disposed;

        protected EntityRepositoryAsync(TContext dbContext)
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

        public async Task<IEnumerable<TResult>> DTOGetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector, CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            var query = Entities.AsNoTracking();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.Select(selector).ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TResult>> DTOGetByAsync<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            var query = Entities.AsNoTracking();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.Where(filter).Select(selector).ToListAsync(cancellationToken);
        }

        public async Task<TResult> DTOGetSingleByAsync<TResult>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TResult>> selector, CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            var query = Entities.AsNoTracking();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.Where(filter).Select(selector).FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
        }


        #endregion

        #region Read Repository
        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            return await Entities.AsNoTracking().AnyAsync(filter, cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            var query = Entities.AsNoTracking();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.ToListAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> filter,  CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            var query = Entities.AsNoTracking();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.Where(filter).ToListAsync(cancellationToken);
        }

        public async Task<TEntity> GetSingleByAsync(Expression<Func<TEntity, bool>> filter,  CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            var query = Entities.AsNoTracking();
            if (includes != null)
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            return await query.Where(filter).FirstOrDefaultAsync(cancellationToken)
                .ConfigureAwait(false);
        }

        #endregion

        #region Entity Repository

        public async Task AddAsync(TEntity item, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            await Entities.AddAsync(item, cancellationToken).ConfigureAwait(false);
        }

        public Task EditAsync(TEntity item, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            Entities.Attach(item);
            //if (item is IHasConcurrencyStamp)
            //    ((IHasConcurrencyStamp)item).ConcurrencyStamp = Guid.NewGuid().ToString();
            Entities.Update(item);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity item, CancellationToken cancellationToken = default(CancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            Entities.Remove(item);
            return Task.CompletedTask;
        }

        #endregion


    }
}
