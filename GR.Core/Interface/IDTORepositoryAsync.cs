using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GR.Core.Interface
{
    public interface IDTORepositoryAsync<TEntity>
       where TEntity : class
    {
        
        //Get all records in list 
        Task<IEnumerable<TResult>> DTOGetAllAsync<TResult>(Expression<Func<TEntity, TResult>> selector,
         CancellationToken cancellationToken = default(CancellationToken),
         params Expression<Func<TEntity, object>>[] includes);


        //Get records in list by filter
        Task<IEnumerable<TResult>> DTOGetByAsync<TResult>(Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TResult>> selector,
            CancellationToken cancellationToken = default(CancellationToken),
            params Expression<Func<TEntity, object>>[] includes);


        //Get single record by filter
        Task<TResult> DTOGetSingleByAsync<TResult>(Expression<Func<TEntity, bool>> filter,
           Expression<Func<TEntity, TResult>> selector,
           CancellationToken cancellationToken = default(CancellationToken),
           params Expression<Func<TEntity, object>>[] includes);


        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter,
           CancellationToken cancellationToken = default(CancellationToken));

    }
}
