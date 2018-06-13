using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GR.Repository.Interface
{
    public interface IEntityRepository<TEntity>
      where TEntity : class
    {
        
        void Add(string requestId, TEntity item);

        void Edit(string requestId, TEntity item);

        void Delete(string requestId, TEntity item);
    }
}
