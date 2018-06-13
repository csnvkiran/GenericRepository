using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GR.Core.Interface
{
    public interface IEntityReadRepository<TEntity>
       where TEntity : class
    {
       
        #region Result By Entity

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns>data list</returns>
        IEnumerable<TEntity> GetLAll(params Expression<Func<TEntity, object>>[] includes);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>data list</returns>
        IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter,  params Expression<Func<TEntity, object>>[] includes);


        /// <summary>
        /// Gets the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>data</returns>
        TEntity GetSingleBy(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);
        
        bool Any(Expression<Func<TEntity, bool>> filter);

        #endregion
        
    }
}
