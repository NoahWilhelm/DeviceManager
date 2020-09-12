using DeviceManager.Core.Devices.Abstractions;
using DeviceManager.Core.Devices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.Testing.API.IntegrationTestHelpers
{

    public class TestingDevicesRepository : IDevicesRepository
    {

        private List<Device> devices;

        public TestingDevicesRepository()
        {
            devices = new List<Device>();
        }

        public async Task<Device> AddAsync(Device item)
        {
            await Task.Yield();
            devices.Add(item);
            return item;
        }

        public async Task CommitAsync()
        {
            await Task.Yield();
        }

        public async Task<Device> FindByIdAsync(int key)
        {
            await Task.Yield();
            return this.devices.FirstOrDefault(x => x.Entry_Id == key);
        }

        public async Task<IQueryable<Device>> GetAllAsync()
        {
            await Task.Yield();
            return this.devices.AsQueryable();
        }

        public void Remove(Device item)
        {
            this.devices.Remove(item);
        }

        public Device Update(Device item)
        {
            var index = this.devices.FirstOrDefault(x => x.Entry_Id == item.Entry_Id);
            this.devices.Remove(index);
            this.devices.Add(item);
            return item;
        }
    }
}
