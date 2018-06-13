using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using GR.Repository.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Localization;
using GR.Repository.Resource;
using System.Threading;
using System.Threading.Tasks;

namespace GR.Repository
{
    /// <summary>
    /// The Entity Framework implementation of IUnitOfWork
    /// </summary>
    public sealed class UnitOfWorkAsync<TContext> : IUnitOfWorkAsync where TContext : DbContext
    {
        /// <summary>
        /// The DbContext
        /// </summary>
        private DbContext _dbContext;
        private readonly ILogger _logger;
        private readonly IStringLocalizer _localizer;


        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="context">The object context</param>
        public UnitOfWorkAsync(TContext dbContext, ILoggerFactory loggerFactory,
            IStringLocalizerFactory localizerFactory)
        {

            _dbContext = dbContext;
            _logger = loggerFactory.CreateLogger<UnitOfWork<TContext>>();
            _localizer = localizerFactory.Create(typeof(UnitOfWork<TContext>)); 
        }



        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public async Task<IEntityResult> SaveAsync(string requestId, CancellationToken cancellationToken = default(CancellationToken))
        {

            try
            {
                _logger.LogInformation(_localizer[RepositoryResource.StartSaveDate], requestId);
                int returnValue;
                returnValue = await _dbContext.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
                if (returnValue >= 0)
                {
                    _logger.LogInformation(_localizer[RepositoryResource.SaveDataSuccess], requestId);
                    return EntitySuccessResult.Success(returnValue);

                }
                else
                {
                    _logger.LogInformation(_localizer[RepositoryResource.SaveChangesFailure], requestId);
                    return EntityErrorResult.Failure(EntityError.DbUpdateFailure);
                }

            }
            catch (DbUpdateConcurrencyException ex)
            {
                _logger.LogError(
                    new EventId(EntityError.ConcurrencyFailure.Code, EntityError.ConcurrencyFailure.Error), ex,
                    _localizer[RepositoryResource.ConcurrencyFailure], requestId);
                return EntityErrorResult.Failure(EntityError.DbUpdateFailure);
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(
                    new EventId(EntityError.DbUpdateFailure.Code, EntityError.DbUpdateFailure.Error), ex,
                    _localizer[RepositoryResource.SaveDataFailure], requestId);
                return EntityErrorResult.Failure(EntityError.DbUpdateFailure);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    new EventId(EntityError.DbUpdateFailure.Code, EntityError.DbUpdateFailure.Error), ex,
                    _localizer[RepositoryResource.SaveDataFailure] , requestId);
                return EntityErrorResult.Failure(EntityError.UnknownFailure);
            }


        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }
    }
}
