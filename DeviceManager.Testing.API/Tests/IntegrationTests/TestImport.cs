using DeviceManager.Core.Devices.Models;
using DeviceManager.Testing.API.IntegrationTestHelpers;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace DeviceManager.Testing.API.Tests.IntegrationTests
{
    public class TestImport : IClassFixture<TestingWebApplicationFactory<TestStartup>>
    {

        private readonly HttpClient testingClient;
        private readonly TestingWebApplicationFactory<TestStartup> factory;

        public TestImport(TestingWebApplicationFactory<TestStartup> factory)
        {

            this.factory = factory;
            this.testingClient = factory.CreateClient();

        }

        [Fact]
        public async Task Test_Import_By_File()
        {

            var currentDirectory = Directory.GetCurrentDirectory();
            var testingFilePath = Path.Combine(currentDirectory, "..", "..", "..", "TestingDevicesFile.json");

            var postRequestContent = MakeJsonFileHttpContent(testingFilePath);

            var postFileResult = await this.testingClient.PostAsync("/jsonFileImport/", postRequestContent);
            var postFileResultText = await postFileResult.Content.ReadAsStringAsync();

            Assert.True(postFileResult.StatusCode == System.Net.HttpStatusCode.OK);

            var postFileResultTextAsDeviceList = JsonSerializer.Deserialize<List<Device>>(postFileResultText);

            Assert.True(postFileResultTextAsDeviceList.Count == 3);

        }

        [Fact]
        public async Task Test_Invalid_File_Import()
        {
            
            var currentDirectory = Directory.GetCurrentDirectory();
            var testingFilePath = Path.Combine(currentDirectory, "..", "..", "..", "InvalidFile.json");

            var httpContent = MakeJsonFileHttpContent(testingFilePath);

            var result = await this.testingClient.PostAsync("/jsonFileImport/", httpContent);
            var isBadRequest = result.StatusCode == System.Net.HttpStatusCode.BadRequest;

            Assert.True(isBadRequest);

        }

        [Fact]
        public async Task Test_Empty_Import()
        {

            var result = await this.testingClient.PostAsync("/jsonFileImport/", null);
            var isBadRequest = result.StatusCode == System.Net.HttpStatusCode.BadRequest;

            Assert.True(isBadRequest);

        }

        private MultipartFormDataContent MakeJsonFileHttpContent(string filePath)
        {
            var resultContent = new MultipartFormDataContent();
            var fileBytes = File.ReadAllBytes(filePath);

            var jsonContent = new ByteArrayContent(fileBytes);
            jsonContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

            resultContent.Add(jsonContent, "file", Path.GetFileName(filePath));

            return resultContent;
        }

    }
}
