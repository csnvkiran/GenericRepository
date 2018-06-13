using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GR.Repository.Interface
{
    public interface IEntityReadRepository<TEntity>
       where TEntity : class
    {
       
        #region Result By Entity

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns>Data list</returns>
        IEnumerable<TEntity> GetAll(string requestId, params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>Data list</returns>
        IEnumerable<TEntity> GetBy(string requestId, Expression<Func<TEntity, bool>> filter,  params Expression<Func<TEntity, object>>[] includes);


        /// <summary>
        /// Gets the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>data</returns>
        TEntity GetSingleBy(string requestId, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);
        

        ///// <summary>
        ///// Check any record exist 
        ///// </summary>
        ///// <param name="filter"></param>
        ///// <returns>boolean</returns>
        //bool Any(Expression<Func<TEntity, bool>> filter);

        #endregion
        
    }
}
