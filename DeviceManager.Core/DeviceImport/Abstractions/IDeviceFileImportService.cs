using DeviceManager.Core.DeviceImport.Model;
using DeviceManager.Core.Devices.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DeviceManager.Core.DeviceImport.Abstractions
{
    public interface IDevicesFileImportService
    {
        Task<IEnumerable<Device>> ImportByJsonTextAsync(string jsonText);
        Task<IEnumerable<Device>> ImportByFormFileAsync(IFormFile formFile);
        Task<IEnumerable<Device>> ImportByModelAsync(DeviceImportModel importModel);
    }
}
