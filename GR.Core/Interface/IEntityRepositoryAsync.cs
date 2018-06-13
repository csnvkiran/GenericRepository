using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GR.Core.Interface
{
    public interface IEntityRepositoryAsync<TEntity>
      where TEntity : class
    {
        
        Task AddAsync(TEntity item, CancellationToken cancellationToken = default(CancellationToken));

        Task EditAsync(TEntity item, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteAsync(TEntity item, CancellationToken cancellationToken = default(CancellationToken));
    }
}
