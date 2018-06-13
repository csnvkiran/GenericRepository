using System;
using System.Collections.Generic;
using System.Text;
using GR.Core.Interface;
namespace GR.Core.Service
{
   
    public interface IDTOService<TResult> : IService
        where TResult : class
    {


        IEnumerable<TResult> GetAll();

        IEnumerable<TResult> GetBy();

        void Create(TResult entity);
        void Delete(TResult entity);
        void Update(TResult entity);

    }
}
