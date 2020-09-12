using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.Core.Core.Abstractions
{
    public interface IRepository<TEntity, TKey> where TEntity : BaseEntityModel<TKey>
    {
        public Task<IQueryable<TEntity>> GetAllAsync();
        public Task<TEntity> FindByIdAsync(TKey key);
        public Task<TEntity> AddAsync(TEntity item);
        public TEntity Update(TEntity item);
        public void Remove(TEntity item);
        public Task CommitAsync();
    }
}
