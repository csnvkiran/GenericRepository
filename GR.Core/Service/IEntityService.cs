using System;
using System.Collections.Generic;
using System.Text;
using GR.Core.Model;
using GR.Core.Interface;
namespace GR.Core.Service
{
    public interface IEntityService<TEntity> : IService
        where TEntity : Entity
    {


        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetBy();

        void Create(TEntity entity);
        void Delete(TEntity entity);
        void Update(TEntity entity);

    }
}
