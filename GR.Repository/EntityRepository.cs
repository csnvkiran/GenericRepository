using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using GR.Model.Interface;
using GR.Repository.Interface;
using GR.Repository.Resource;

//using System.Threading;
//using System.Threading.Tasks;

namespace GR.Repository
{
    public abstract class EntityRepository<TEntity, TContext> : IEntityReadRepository<TEntity>, IEntityRepository<TEntity>, IDisposable
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected DbSet<TEntity> Entities;
        private readonly ILogger _logger;
        private readonly IStringLocalizer _localizer;

        private bool _disposed;

        protected EntityRepository(TContext dbContext, ILoggerFactory loggerFactory,
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


        public bool Any(string requestId, Expression<Func<TEntity, bool>> filter)
        {
          
            //Log Request start Message
            _logger.LogInformation(_localizer[RepositoryResource.StartReadData], requestId);

            //Check for Repository
            ThrowIfDisposed();

            bool result = false;
            try
            {
                result = Entities.AsNoTracking().Any(filter);
                
            }
            catch (Exception ex)
            {
                //Log Exucution Error Message
                _logger.LogError(
                   new EventId(EntityError.DbReadFailure.Code, EntityError.DbReadFailure.Error), ex,
                   _localizer[RepositoryResource.ReadDateFailure], requestId);

                throw;

            }

            _logger.LogInformation(_localizer[RepositoryResource.ReadDataSuccess], requestId);
            return result;
        }

        public IEnumerable<TEntity> GetAll(string requestId, params Expression<Func<TEntity, object>>[] includes)
        {
            //Check for Repository
            ThrowIfDisposed();

            //Log Request start Message
            _logger.LogInformation(_localizer[RepositoryResource.StartReadData], requestId);

            //Execute Request
            IEnumerable<TEntity> result = null;
            try
            {
                var query = Entities.AsNoTracking();

                if (includes != null)
                    query = includes.Aggregate(query, (current, include) => current.Include(include));

                result = query.ToList();

                //Log Request Success Message
                _logger.LogInformation(_localizer[RepositoryResource.ReadDataSuccessWithCount], result.Count(), requestId);
                // _logger.LogInformation(_localizer[RepositoryResource.ReadDataSuccess], requestId);

                //Return Requested Data
                return result;
            }
           
            catch (Exception ex)
            {

                //Log Exucution Error Message
                _logger.LogError(
                   new EventId(EntityError.DbReadFailure.Code, EntityError.DbReadFailure.Error), ex,
                   _localizer[RepositoryResource.ReadDateFailure], requestId);

                throw;
            }


           
        }

        public IEnumerable<TEntity> GetBy(string requestId, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            //Check for Repository
            ThrowIfDisposed();

            _logger.LogInformation(_localizer[RepositoryResource.StartReadData], requestId);

            IEnumerable<TEntity> result = null;
            try
            {
                var query = Entities.AsNoTracking();

                if (includes != null)
                    query = includes.Aggregate(query, (current, include) => current.Include(include));

                result = query.Where(filter).AsEnumerable<TEntity>();
            }
            catch (Exception ex)
            {
                _logger.LogError(
                  new EventId(EntityError.DbReadFailure.Code, EntityError.DbReadFailure.Error), ex,
                  _localizer[RepositoryResource.ReadDateFailure], requestId);

                throw;
            }

            //Log Request Success Message
            _logger.LogInformation(_localizer[RepositoryResource.ReadDataSuccessWithCount], result.Count(), requestId);

            return result;
        }


        public TEntity GetSingleBy(string requestId, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes)
        {
            //Check for Repository
            ThrowIfDisposed();

            _logger.LogInformation(_localizer[RepositoryResource.StartReadData], requestId);

            TEntity result = null;

            try
            {
                var query = Entities.AsNoTracking();
                if (includes != null)
                    query = includes.Aggregate(query, (current, include) => current.Include(include));

                result = query.Where(filter).FirstOrDefault();
            }
            catch (Exception ex)
            {

                _logger.LogError(
                 new EventId(EntityError.DbReadFailure.Code, EntityError.DbReadFailure.Error), ex,
                 _localizer[RepositoryResource.ReadDateFailure], requestId);

                throw;
            }

            //Log Request Success Message
            _logger.LogInformation(_localizer[RepositoryResource.ReadDataSuccess], requestId);

            return result;
        }

        #endregion


        #region Entity Repository
        public void Add(string requestId, TEntity item)
        {
            

            _logger.LogInformation(_localizer[RepositoryResource.AddDataStart], requestId);

            ThrowIfDisposed();

            if (item == null)
                throw new ArgumentNullException(nameof(item));

            try
            {
                Entities.Add(item);
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

        public void Edit(string requestId, TEntity item)
        {

            _logger.LogInformation(_localizer[RepositoryResource.EditDataStart], requestId);

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


        }

        public void Delete(string requestId, TEntity item)
        {
            _logger.LogInformation(_localizer[RepositoryResource.DeleteDataStart], requestId);

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

        }


        #endregion


    }
}
