using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GR.Repository.Interface
{
    public interface IEntityRepositoryAsync<TEntity>
      where TEntity : class
    {
        
        Task AddAsync(string requestId, TEntity item, CancellationToken cancellationToken = default(CancellationToken));

        Task EditAsync(string requestId, TEntity item, CancellationToken cancellationToken = default(CancellationToken));

        Task DeleteAsync(string requestId, TEntity item, CancellationToken cancellationToken = default(CancellationToken));
    }
}
