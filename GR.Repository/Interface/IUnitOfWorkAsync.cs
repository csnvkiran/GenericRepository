using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GR.Repository.Interface
{
    public interface IUnitOfWorkAsync : IDisposable
    {

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        Task<IEntityResult> SaveAsync(string requestId, CancellationToken cancellationToken = default(CancellationToken));
    }
}
