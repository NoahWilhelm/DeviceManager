using DeviceManager.Core.DeviceImport.Model;
using DeviceManager.Core.Devices.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.Testing.Core.DeviceImport
{
    public static class DeviceImport_TestData
    {

        public static DeviceImportModel GetTestImportModel()
        {
            var result = new DeviceImportModel();
            result.Devices = new List<Device>();

            var device1 = new Device()
            {
                Id = "Testing_Device_1",
                TempMin = 0,
                TempMax = 10,
                Failsafe = false
            };

            var device2 = new Device()
            {
                Id = "Testing_Device_2",
                TempMin = 10,
                TempMax = 15,
                Failsafe = false
            };

            var device3 = new Device()
            {
                Id = "Testing_Device_3",
                TempMin = 10,
                TempMax = 15,
                Failsafe = true,
                InsertInto19InchCabinet = true
            };

            result.Devices.Add(device1);
            result.Devices.Add(device2);
            result.Devices.Add(device3);

            return result;

        }

    }
}
