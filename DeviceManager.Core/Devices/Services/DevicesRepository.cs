using DeviceManager.Core.Core.Abstractions;
using DeviceManager.Core.Core.Services;
using DeviceManager.Core.Devices.Abstractions;
using DeviceManager.Core.Devices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.Core.Devices.Services
{
    public class DevicesRepository : IDevicesRepository
    {

        private readonly DataContext dataContext;

        public DevicesRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<Device> AddAsync(Device item)
        {
            var result = await this.dataContext.Devices.AddAsync(item);
            return result.Entity;
        }

        public Task CommitAsync()
        {
            return this.dataContext.SaveChangesAsync();
        }

        public async Task<Device> FindByIdAsync(int key)
        {
            var allEntries = await this.GetAllAsync();
            return allEntries.FirstOrDefault(x => x.Entry_Id == key);
        }

        public async Task<IQueryable<Device>> GetAllAsync()
        {
            await Task.Yield();
            return this.dataContext.Devices.AsQueryable();
        }

        public void Remove(Device item)
        {
            this.dataContext.Devices.Remove(item);
        }

        public Device Update(Device item)
        {
            var result = this.dataContext.Update(item);
            return result.Entity;
        }
    }
}
