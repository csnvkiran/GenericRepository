using System;
using System.Collections.Generic;
using System.Text;
using GR.Model;
using System.Linq.Expressions;
using GR.Model.Interface;

namespace GR.Service.Interface
{
    public interface IEntityServiceAED<TEntity, SModel> : IService
        where TEntity : IEntity
        where SModel : class
    {

        //IEnumerable<TEntity> GetAll();

        //IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);
        IResponse Add(string requestId, SModel SaveModel);
        IResponse AddBulk(string requestId, SModel SaveModel, Boolean doCommit);

        IResponse Delete(string requestId, TEntity SaveModel);
        IResponse Edit(string requestId, SModel SaveModel);

    }
}
