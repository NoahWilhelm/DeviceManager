using DeviceManager.Core.Core.Abstractions;
using DeviceManager.Core.Devices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.Core.Devices.Abstractions
{
    public interface IDevicesRepository : IRepository<Device, int>
    {
    }
}
