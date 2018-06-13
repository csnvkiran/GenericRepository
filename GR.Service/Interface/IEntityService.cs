using System;
using System.Collections.Generic;
using System.Text;
using GR.Model;
using System.Linq.Expressions;

namespace GR.Service.Interface
{
    public interface IEntityService<TEntity> : IService
        where TEntity : Entity
    {

        //IEnumerable<TEntity> GetAll();

        //IEnumerable<TEntity> GetBy(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);
        IResponse GetAll(string requestId, params Expression<Func<TEntity, object>>[] includes);

        IResponse GetBy(string requestId, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        IResponse GetSingleBy(string requestId, Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] includes);

        //void Add(TEntity entity);
        //void Delete(TEntity entity);
        //void Edit(TEntity entity);

    }
}
