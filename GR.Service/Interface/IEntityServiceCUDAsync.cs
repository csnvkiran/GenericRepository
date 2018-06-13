using System;
using System.Collections.Generic;
using System.Text;
using GR.Model;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;

namespace GR.Service.Interface
{
    public interface IEntityServiceCUDAsync<TEntity, SModel> : IService
        where TEntity : Entity
        where SModel : class
    {


        //Task<IEnumerable<TEntity>> GetAllAsync(
        // CancellationToken cancellationToken = default(CancellationToken),
        // params Expression<Func<TEntity, object>>[] includes);

        //IEnumerable<TEntity> GetByAsync(
        //CancellationToken cancellationToken = default(CancellationToken),
        //params Expression<Func<TEntity, object>>[] includes);


        Task<IResponse> AddAsync(string requestId, SModel SaveModel, CancellationToken cancellationToken = default(CancellationToken));
        Task<IResponse> AddBulkAsync(string requestId, SModel SaveModel, Boolean doCommit, CancellationToken cancellationToken = default(CancellationToken));
        Task<IResponse> DeleteAsync(string requestId, Expression<Func<TEntity, bool>> filter, CancellationToken cancellationToken = default(CancellationToken));
        Task<IResponse> EditAsync(string requestId, SModel SaveModel, CancellationToken cancellationToken = default(CancellationToken));


    }
}
