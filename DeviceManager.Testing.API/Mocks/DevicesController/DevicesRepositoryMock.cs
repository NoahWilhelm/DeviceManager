using DeviceManager.Core.Devices.Abstractions;
using DeviceManager.Core.Devices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.Testing.API.Mocks.DevicesController
{
    public class DevicesRepositoryMock : IDevicesRepository
    {

        private List<Device> devices { get; set; }

        public DevicesRepositoryMock()
        {
            devices = new List<Device>();
            devices.AddRange(GetTestingDevices().ToList());
        }

        public void ClearAll()
        {
            this.devices = new List<Device>();
        }

        public static IEnumerable<Device> GetTestingDevices()
        {

            yield return new Device()
            {
                Entry_Id = 0,
                Name = "Testing_Device_1",
                Id = "TD1",
                Failsafe = true
            };

            yield return new Device()
            {
                Entry_Id = 1,
                Name = "Testing_Device_2",
                Id = "TD2",
                Failsafe = false
            };

            yield return new Device()
            {
                Entry_Id = 2,
                Name = "Testing_Device_3",
                Id = "TD3",
                Failsafe = true,
                DeviceTypeId = "Testing"
            };

        }

        public async Task<Device> AddAsync(Device item)
        {
            await Task.Yield();
            this.devices.Add(item);
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
            var originalItemIndex = this.devices.IndexOf(item);
            this.devices.RemoveAt(originalItemIndex);
            this.devices.Add(item);
            return item;
        }
    }
}
