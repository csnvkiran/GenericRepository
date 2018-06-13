using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using GR.Model.Interface;

namespace GR.Service.Interface
{
   
    public interface IModelService<TEntity> : IService
        where TEntity : IEntity
    {

        IResponse GetAllModel(string requestId,  params Expression<Func<TEntity, object>>[] includes);

        IResponse GetByModel(string requestId, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

 
    }
}
