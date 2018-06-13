using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GR.Core.Interface
{
    public interface IRepository<TEntity>
       where TEntity : class
    {

        #region Result By Model

        IEnumerable<TResult> DTOGetAll<TResult>(Expression<Func<TEntity, TResult>> selector,
           params Expression<Func<TEntity, object>>[] includes);


        IEnumerable<TResult> DTOGetBy<TResult>(Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TResult>> selector,
            params Expression<Func<TEntity, object>>[] includes);


        TResult DTOGetSingleBy<TResult>(Expression<Func<TEntity, bool>> filter,
           Expression<Func<TEntity, TResult>> selector,
           params Expression<Func<TEntity, object>>[] includes);

        #endregion

        #region Result By Entity


        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <returns>data list</returns>
        IEnumerable<TEntity> GetList();

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>data list</returns>
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> condition);


        /// <summary>
        /// Gets the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>data</returns>
        TEntity Get(Expression<Func<TEntity, bool>> condition);



        bool All(Expression<Func<TEntity, bool>> filter);

        
        bool Any(Expression<Func<TEntity, bool>> filter);

        #endregion

        
    }
}
