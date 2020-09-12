using DeviceManager.Core.DeviceImport.Abstractions;
using DeviceManager.Core.DeviceImport.Exceptions;
using DeviceManager.Core.DeviceImport.Model;
using DeviceManager.Core.Devices.Abstractions;
using DeviceManager.Core.Devices.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DeviceManager.Core.DeviceImport.Services
{
    public class DevicesFileImportService : IDevicesFileImportService
    {

        private readonly IDevicesRepository devicesRepository;

        public DevicesFileImportService(IDevicesRepository devicesRepository)
        {
            this.devicesRepository = devicesRepository;
        }

        private DeviceImportModel GetModelByJsonText(string jsonText)
        {

            if (string.IsNullOrEmpty(jsonText)) throw new InvalidImportFileTextException("Text is empty");

            try
            {
                var result = JsonSerializer.Deserialize<DeviceImportModel>(jsonText, new JsonSerializerOptions()
                {
                    IgnoreNullValues = true,
                    PropertyNameCaseInsensitive = true
                });

                if (result.Devices == null) throw new InvalidImportFileTextException("Text is not a valid DeviceImportModel");

                return result;

            } catch (Exception e)
            {
                throw new InvalidImportFileTextException("Text is not a valid DeviceImportModel");
            }
        }

        public async Task<IEnumerable<Device>> ImportByModelAsync(DeviceImportModel importModel)
        {
            
            foreach (var device in importModel.Devices)
            {
                await devicesRepository.AddAsync(device);
            }

            await devicesRepository.CommitAsync();

            return importModel.Devices;

        }

        public async Task<IEnumerable<Device>> ImportByFormFileAsync(IFormFile formFile)
        {
            using(var streamReader = new StreamReader(formFile.OpenReadStream()))
            {
                var jsonText = await streamReader.ReadToEndAsync();
                var result = await ImportByJsonTextAsync(jsonText);
                return result;
            }
        }

        public async Task<IEnumerable<Device>> ImportByJsonTextAsync(string jsonText)
        {
            var model = GetModelByJsonText(jsonText);
            var result = await this.ImportByModelAsync(model);
            return result;
        }
    }
}
