using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GR.Core.Interface
{
    public interface IEntityReadRepositoryAsync<TEntity>
       where TEntity : class
    {

        //Get all records in list 
        Task<IEnumerable<TEntity>> GetAllAsync(
         CancellationToken cancellationToken = default(CancellationToken),
         params Expression<Func<TEntity, object>>[] includes);


        //Get records in list by filter
        Task<IEnumerable<TEntity>> GetByAsync(Expression<Func<TEntity, bool>> filter,
            CancellationToken cancellationToken = default(CancellationToken),
            params Expression<Func<TEntity, object>>[] includes);


        //Get single record by filter
        Task<TEntity> GetSingleByAsync(Expression<Func<TEntity, bool>> filter,
           CancellationToken cancellationToken = default(CancellationToken),
           params Expression<Func<TEntity, object>>[] includes);


        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter,
           CancellationToken cancellationToken = default(CancellationToken));

    }
}
