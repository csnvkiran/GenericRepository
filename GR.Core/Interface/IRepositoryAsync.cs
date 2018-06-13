using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GR.Core.Interface.Model
{
    public interface IRepositoryAsync<TEntity>
       where TEntity : class
    {
        //Get all records in list 
        Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
         CancellationToken cancellationToken = default(CancellationToken),
         params Expression<Func<TEntity, object>>[] includes);

        //Get records in list by filter
        Task<IEnumerable<TResult>> GetByAsync<TResult>(Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TResult>> selector,
            CancellationToken cancellationToken = default(CancellationToken),
            params Expression<Func<TEntity, object>>[] includes);

        //Get single record by filter
        Task<TResult> GetSingleByAsync<TResult>(Expression<Func<TEntity, bool>> filter,
           Expression<Func<TEntity, TResult>> selector,
           CancellationToken cancellationToken = default(CancellationToken),
           params Expression<Func<TEntity, object>>[] includes);


        Task<bool> AllAsync(Expression<Func<TEntity, bool>> filter,
           CancellationToken cancellationToken = default(CancellationToken));


        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter,
           CancellationToken cancellationToken = default(CancellationToken));

    }
}
