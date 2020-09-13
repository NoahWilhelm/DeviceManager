using DeviceManager.Core.Config;
using DeviceManager.Core.Devices.Models;
using DeviceManager.Testing.API.IntegrationTestHelpers;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DeviceManager.Testing.API.Tests.IntegrationTests
{
    public class DevicesControllerTest : IClassFixture<TestingWebApplicationFactory<TestStartup>>
    {
        private readonly HttpClient testingClient;
        private readonly TestingWebApplicationFactory<TestStartup> factory;

        public DevicesControllerTest(TestingWebApplicationFactory<TestStartup> factory)
        {
            // Arrange
            this.factory = factory;
            this.testingClient = factory.CreateClient();
        }

        [Fact]
        public async Task Test_Get_Without_Id()
        {

            // Act
            var result = await testingClient.GetAsync("/api/devices/");
            var isOkay = result.StatusCode == System.Net.HttpStatusCode.OK;
            var resultText = await result.Content.ReadAsStringAsync();
            var resultAsDeviceList = JsonSerializer.Deserialize<List<Device>>(resultText, DefaultJsonSerializerOptions.IgnoreCase());
            var resultDevicesCount = resultAsDeviceList.Count;

            // Assert
            Assert.True(isOkay);
            Assert.Equal(1, resultDevicesCount);

        }

        [Fact]
        public async Task Test_Get_With_Valid_Id()
        {

            // Act
            var result = await testingClient.GetAsync("/api/devices/0");
            var isOkay = result.StatusCode == System.Net.HttpStatusCode.OK;
            var resultText = await result.Content.ReadAsStringAsync();
            var resultAsDevice = JsonSerializer.Deserialize<Device>(resultText, DefaultJsonSerializerOptions.IgnoreCase());
            var expectedDeviceName = "Testing Device 0";

            // Assert
            Assert.True(isOkay);
            Assert.Equal(expectedDeviceName, resultAsDevice.Name);

        }

        [Fact]
        public async Task Test_Get_With_Invalid_Id()
        {

            // Act
            var result = await testingClient.GetAsync("/api/devices/100");
            var isNotFound = result.StatusCode == System.Net.HttpStatusCode.NotFound;

            // Assert
            Assert.True(isNotFound);

        }
    }
}
