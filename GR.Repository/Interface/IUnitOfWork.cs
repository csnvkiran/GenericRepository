﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GR.Repository.Interface
{
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        IEntityResult Save(string requestId);
    }
}
