using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace GR.Core.Interface
{
    public interface IDTORepository<TEntity>
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

        bool Any(Expression<Func<TEntity, bool>> filter);

        #endregion


    }
}
