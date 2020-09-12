using DeviceManager.Core.Devices.Abstractions;
using DeviceManager.Core.Devices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.Testing.Core.Mocks
{
    public class DeviceRepositoryMock : IDevicesRepository
    {

        private List<Device> Devices { get; set; }

        public DeviceRepositoryMock()
        {
            this.Devices = new List<Device>();
        }

        public async Task<Device> AddAsync(Device item)
        {
            await Task.Yield();
            this.Devices.Add(item);
            return item;
        }

        public Task CommitAsync()
        {
            return Task.CompletedTask;
        }

        public async Task<Device> FindByIdAsync(int key)
        {
            await Task.Yield();
            return this.Devices.FirstOrDefault(x => x.Entry_Id == key);
        }

        public async Task<IQueryable<Device>> GetAllAsync()
        {
            await Task.Yield();
            return this.Devices.AsQueryable();
        }

        public Device Update(Device item)
        {
            var byId = this.Devices.FirstOrDefault(x => x.Entry_Id == item.Entry_Id);
            byId = item;
            return item;
        }

        public void Remove(Device item)
        {
            this.Devices.Remove(item);
        }
    }
}
