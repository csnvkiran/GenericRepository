using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GR.Repository.Interface
{
    public interface IEntityReadRepositoryAsync<TEntity>
       where TEntity : class
    {

        //Get all records in list 
        /// <summary>
        /// Get complete data Async
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <param name="includes"></param>
        /// <returns>data list</returns>
        Task<IEnumerable<TEntity>> GetAllAsync(string requestId,
         CancellationToken cancellationToken = default(CancellationToken),
         params Expression<Func<TEntity, object>>[] includes);


        //Get records in list by filter
        /// <summary>
        ///  Get data by filter Async
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="includes"></param>
        /// <returns>data list</returns>
        Task<IEnumerable<TEntity>> GetByAsync(string requestId, 
            Expression<Func<TEntity, bool>> filter,
            CancellationToken cancellationToken = default(CancellationToken),
            params Expression<Func<TEntity, object>>[] includes);


        
        /// <summary>
        /// Get single record by filter Async
        /// </summary>
        /// <param name="filter"></param>
        /// <param name="cancellationToken"></param>
        /// <param name="includes"></param>
        /// <returns>data</returns>
        Task<TEntity> GetSingleByAsync(string requestId, 
            Expression<Func<TEntity, bool>> filter,
           CancellationToken cancellationToken = default(CancellationToken),
           params Expression<Func<TEntity, object>>[] includes);

        ///// <summary>
        ///// Check any record by filter Async
        ///// </summary>
        ///// <param name="filter"></param>
        ///// <param name="cancellationToken"></param>
        ///// <returns>Boolean</returns>
        //Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter,
        //   CancellationToken cancellationToken = default(CancellationToken));

    }
}
