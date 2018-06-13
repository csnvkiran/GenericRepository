using System;
using System.Collections.Generic;
using System.Text;
using GR.Model;
using System.Threading.Tasks;
using System.Threading;
using System.Linq.Expressions;

namespace GR.Service.Interface
{
    public interface IEntityServiceAsync<TEntity> : IService
        where TEntity : Entity
    {


        Task<IResponse> GetAllAsync(string requestId,
         CancellationToken cancellationToken = default(CancellationToken),
         params Expression<Func<TEntity, object>>[] includes);

        Task<IResponse> GetByAsync(string requestId, Expression<Func<TEntity, bool>> filter,
         CancellationToken cancellationToken = default(CancellationToken),
         params Expression<Func<TEntity, object>>[] includes);

        Task<IResponse> GetSingleByAsync(string requestId, Expression<Func<TEntity, bool>> filter,
        CancellationToken cancellationToken = default(CancellationToken),
        params Expression<Func<TEntity, object>>[] includes);

        //void AddAsync(TEntity entity);
        //void DeleteAsync(TEntity entity);
        //void EditAsync(TEntity entity);

    }
}
