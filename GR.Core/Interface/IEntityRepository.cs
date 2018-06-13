using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GR.Core.Interface
{
    public interface IEntityRepository<TEntity>
      where TEntity : class
    {
        
        void Add(TEntity item);

        void Edit(TEntity item);

        void Delete(TEntity item);
    }
}
