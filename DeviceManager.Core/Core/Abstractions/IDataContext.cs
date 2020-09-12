using DeviceManager.Core.Devices.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DeviceManager.Core.Core.Abstractions
{
    public interface IDataContext
    {
        // Sets
        public DbSet<Device> Devices { get; set; }

        // Default Methods
        public ValueTask<EntityEntry<TEntity>> AddAsync<TEntity>(TEntity entity, CancellationToken cancellationToken = default) where TEntity : class;
        public EntityEntry<TEntity> Update<TEntity>(TEntity entity) where TEntity : class;
        public EntityEntry<TEntity> Remove<TEntity>(TEntity entity) where TEntity : class;
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
