using DeviceManager.Core.DeviceImport.Abstractions;
using DeviceManager.Core.DeviceImport.Exceptions;
using DeviceManager.Core.DeviceImport.Services;
using DeviceManager.Core.Devices.Abstractions;
using DeviceManager.Testing.Core.Mocks;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DeviceManager.Testing.Core.DeviceImport
{
    public class DeviceFileImportService_Test
    {

        private readonly IDevicesFileImportService testingInstance;
        private readonly IDevicesRepository devicesRepository;

        public DeviceFileImportService_Test()
        {
            this.devicesRepository = new DeviceRepositoryMock();
            testingInstance = new DevicesFileImportService(devicesRepository);
        }

        [Fact]
        public async Task ImportByModel_Test()
        {
            var testingModel = DeviceImport_TestData.GetTestImportModel();
            var testImport = await testingInstance.ImportByModelAsync(testingModel);
            var expectedDevices = testingModel.Devices.OrderBy(x => x.Id).ToList();
            var devicesInRepository = await devicesRepository.GetAllAsync();
            var devicesInRepositorySorted = devicesInRepository.OrderBy(x => x.Id).ToList();

            Assert.Equal(expectedDevices, devicesInRepositorySorted);
        }

        [Fact]
        public async Task ImportByJsonText_Test_ShouldSucceed()
        {
            var testingModel = DeviceImport_TestData.GetTestImportModel();
            var testingModelAsValidJson = JsonSerializer.Serialize(testingModel);
            var testImport = await testingInstance.ImportByJsonTextAsync(testingModelAsValidJson);

            var expectedDevices = testingModel.Devices.OrderBy(x => x.Id);
            var devicesInRepository = await devicesRepository.GetAllAsync();
            var devicesInRepositorySorted = devicesInRepository.OrderBy(x => x.Id);

            var expected = expectedDevices.ToList();
            var result = devicesInRepositorySorted.ToList();

            Assert.Equal(expected, result);
        }

        [Fact]
        public async Task ImportByFormFileAsync_Test()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var testingFilePath = Path.Combine(currentDirectory, "..", "..", "..", "DeviceImport", "TestingDevicesFile.json");
            var testingFormFile = FormFileMockFactory.CreateFormFileByFileInfo("application/json", new FileInfo(testingFilePath));
            var expectedNewDevices = DeviceImport_TestData.GetTestImportModel().Devices.OrderBy(x => x.Id).ToList();
            var result = await testingInstance.ImportByFormFileAsync(testingFormFile);

            var allDevices = await devicesRepository.GetAllAsync();
            var allDevicesResult = allDevices.OrderBy(x => x.Id).ToList();

            Assert.Equal(expectedNewDevices, allDevicesResult);

        }

        [Fact]
        public async Task ImportByJsonText_Empty_Text()
        {
            var testingTask = testingInstance.ImportByJsonTextAsync("");

            await Assert.ThrowsAsync<InvalidImportFileTextException>(() => testingTask);
        }

        [Fact]
        public async Task ImportByJsonText_Invalid_Json()
        {
            var testingTask = testingInstance.ImportByJsonTextAsync("Not a valid json text");

            await Assert.ThrowsAsync<InvalidImportFileTextException>(() => testingTask);
        }

        [Fact]
        public async Task ImportByJsonText_Invalid_Model()
        {
            var testingTask = testingInstance.ImportByJsonTextAsync("{ \"Prop1\": true }");

            await Assert.ThrowsAsync<InvalidImportFileTextException>(() => testingTask);
        }

    }
}
