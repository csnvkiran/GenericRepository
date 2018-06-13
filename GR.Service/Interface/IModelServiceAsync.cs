using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using GR.Model.Interface;
using System.Threading.Tasks;
using System.Threading;

namespace GR.Service.Interface
{
   
    public interface IModelServiceAsync<TEntity> : IService
        where TEntity : IEntity
    {

        Task<IResponse> GetAllModelAsync(string requestId,
         CancellationToken cancellationToken = default(CancellationToken),
         params Expression<Func<TEntity, object>>[] includes);



        Task<IResponse> GetByModelAsync(string requestId, Expression<Func<TEntity, bool>> filter,
         CancellationToken cancellationToken = default(CancellationToken),
         params Expression<Func<TEntity, object>>[] includes);



    }
}
