using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GR.Model.Interface;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Threading;
using System.Linq;
using GR.Repository.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using GR.Repository.Resource;

namespace GR.Repository
{
    public abstract class EntityRepositoryAsync<TEntity, TContext> : IEntityReadRepositoryAsync<TEntity>, IEntityRepositoryAsync<TEntity>, IDisposable
      where TEntity : class, IEntity
      where TContext : DbContext
    {
        protected readonly DbSet<TEntity> Entities;
        private readonly ILogger _logger;
        private readonly IStringLocalizer _localizer;

        private bool _disposed;

        protected EntityRepositoryAsync(TContext dbContext, ILoggerFactory loggerFactory,
            IStringLocalizerFactory localizerFactory)
        {
            Entities = dbContext.Set<TEntity>();
            _logger = loggerFactory.CreateLogger<UnitOfWork<TContext>>();
            _localizer = localizerFactory.Create(typeof(UnitOfWork<TContext>));
        }

        protected void ThrowIfDisposed()
        {
            if (_disposed)
            {
                _logger.LogInformation(_localizer[RepositoryResource.RepositoryDisposed]);

                throw new ObjectDisposedException(GetType().Name);
            }
                
        }

        public void Dispose()
        {
            _disposed = true;
        }


        #region Read Repository
        public async Task<bool> AnyAsync(string requestId, Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default(CancellationToken))
        {
            //Log Request start Message
            _logger.LogInformation(_localizer[RepositoryResource.StartReadData], requestId);

            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            bool result = false;
            try
            {

                _logger.LogInformation(_localizer[RepositoryResource.ReadDataSuccess], requestId);

                result = await Entities.AsNoTracking().AnyAsync(filter, cancellationToken);

                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError(
                    new EventId(EntityError.DbReadFailure.Code, EntityError.DbReadFailure.Error), ex,
                    _localizer[RepositoryResource.ReadDateFailure], requestId);

                throw;
            }


           
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(string requestId, CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {
            //Log Request start Message
            _logger.LogInformation(_localizer[RepositoryResource.StartReadData], requestId);

            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            IEnumerable<TEntity> result = null;
            try
            {
                var query = Entities.AsNoTracking();
                if (includes != null)
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
                result = await query.ToListAsync(cancellationToken).ConfigureAwait(false);

                _logger.LogInformation(_localizer[RepositoryResource.ReadDataSuccessWithCount], result.Count(), requestId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    new EventId(EntityError.DbReadFailure.Code, EntityError.DbReadFailure.Error), ex,
                    _localizer[RepositoryResource.ReadDateFailure], requestId);

                throw;
            }

          
        }

        public async Task<IEnumerable<TEntity>> GetByAsync(string requestId, Expression<Func<TEntity, bool>> filter,  CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {
            //Log Request start Message
            _logger.LogInformation(_localizer[RepositoryResource.StartReadData], requestId);


            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            IEnumerable<TEntity> result = null;
            try
            {
                var query = Entities.AsNoTracking();
                if (includes != null)
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
                result = await query.Where(filter).ToListAsync(cancellationToken);

                _logger.LogInformation(_localizer[RepositoryResource.ReadDataSuccessWithCount], result.Count(), requestId);

                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError(
                 new EventId(EntityError.DbReadFailure.Code, EntityError.DbReadFailure.Error), ex,
                 _localizer[RepositoryResource.ReadDateFailure], requestId);

                throw;
            }

        


        }

        public async Task<TEntity> GetSingleByAsync(string requestId, Expression<Func<TEntity, bool>> filter,  CancellationToken cancellationToken = default(CancellationToken), params Expression<Func<TEntity, object>>[] includes)
        {
            //Log Request start Message
            _logger.LogInformation(_localizer[RepositoryResource.StartReadData], requestId);

            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            TEntity result = null;
            try
            {
                var query = Entities.AsNoTracking();
                if (includes != null)
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
                result = await query.Where(filter).FirstOrDefaultAsync(cancellationToken)
                    .ConfigureAwait(false);

                //Log Request Success Message
                _logger.LogInformation(_localizer[RepositoryResource.ReadDataSuccess], requestId);

                return result;
            }
            catch (Exception ex)
            {

                _logger.LogError(
                  new EventId(EntityError.DbReadFailure.Code, EntityError.DbReadFailure.Error), ex,
                  _localizer[RepositoryResource.ReadDateFailure], requestId);

                throw;
            }

           

        }

        #endregion

        #region Entity Repository

        public async Task AddAsync(string requestId, TEntity item, CancellationToken cancellationToken = default(CancellationToken))
        {

            _logger.LogInformation(_localizer[RepositoryResource.AddDataStart], requestId);
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            try
            {
                await Entities.AddAsync(item, cancellationToken).ConfigureAwait(false);
                _logger.LogInformation(_localizer[RepositoryResource.AddDataSuccess], requestId);
            }
            catch (Exception ex)
            {

                _logger.LogError(
                 new EventId(EntityError.DbUpdateFailure.Code, EntityError.DbUpdateFailure.Error), ex,
                 _localizer[RepositoryResource.AddDataFailure], requestId);

                throw;
            }
            
        }

        public Task EditAsync(string requestId, TEntity item, CancellationToken cancellationToken = default(CancellationToken))
        {

            _logger.LogInformation(_localizer[RepositoryResource.EditDataStart], requestId);
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (item == null)
                throw new ArgumentNullException(nameof(item));

            try
            {
                Entities.Attach(item);
                //if (item is IHasConcurrencyStamp)
                //    ((IHasConcurrencyStamp)item).ConcurrencyStamp = Guid.NewGuid().ToString();
                Entities.Update(item);
                _logger.LogInformation(_localizer[RepositoryResource.EditDataSuccess], requestId);
            }
            catch (Exception ex)
            {

                _logger.LogError(
                 new EventId(EntityError.DbUpdateFailure.Code, EntityError.DbUpdateFailure.Error), ex,
                 _localizer[RepositoryResource.EditDataFailure], requestId);

                throw;

            }

            return Task.CompletedTask;
        }

        public Task DeleteAsync(string requestId, TEntity item, CancellationToken cancellationToken = default(CancellationToken))
        {

            _logger.LogInformation(_localizer[RepositoryResource.DeleteDataStart], requestId);

            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (item == null)
                throw new ArgumentNullException(nameof(item));
            try
            {
                Entities.Remove(item);
                _logger.LogInformation(_localizer[RepositoryResource.DeleteDataSuccess], requestId);
            }
            catch (Exception ex)
            {

                _logger.LogError(
                 new EventId(EntityError.DbUpdateFailure.Code, EntityError.DbUpdateFailure.Error), ex,
                 _localizer[RepositoryResource.DeleteDataFailure], requestId);

                throw;
            }
            
            return Task.CompletedTask;
        }

        #endregion


    }
}
