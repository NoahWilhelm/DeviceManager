using DeviceManager.API.Controllers;
using DeviceManager.Core.Devices.Models;
using DeviceManager.Testing.API.Mocks.DevicesController;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DeviceManager.Testing.API.Tests.UnitTests
{
    public class DevicesControllerTest
    {

        private readonly DevicesController testingInstance;

        public DevicesControllerTest()
        {
            testingInstance = new DevicesController(new DevicesRepositoryMock()) {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
        }

        [Fact]
        public async Task Test_Get_Method_Without_Id()
        {

            var result = await testingInstance.Get(null);
            var expectedList = DevicesRepositoryMock.GetTestingDevices().OrderBy(x => x.Entry_Id).ToList();

            var asOkObjectResult = Assert.IsAssignableFrom<OkObjectResult>(result);

            var resultList = asOkObjectResult.Value as IQueryable<Device>;
            var resultListSorted = resultList.OrderBy(x => x.Entry_Id).ToList();

            Assert.Equal(expectedList, resultListSorted);

        }

        [Fact]
        public async Task Test_Get_Method_With_Id()
        {
            var result = await testingInstance.Get(1);
            var expectedResult = DevicesRepositoryMock.GetTestingDevices().FirstOrDefault(x => x.Entry_Id == 1);

            var asOkObjectResult = Assert.IsAssignableFrom<OkObjectResult>(result);

            var resultDevice = asOkObjectResult.Value as Device;

            Assert.Equal(expectedResult, resultDevice);
        }

        [Fact]
        public async Task Test_Get_Method_With_Invalid_Id()
        {
            
            var result = await testingInstance.Get(100);
            var resultAsNotFoundObjectResult = Assert.IsAssignableFrom<NotFoundObjectResult>(result);

            var isStatusCodeCorrect = resultAsNotFoundObjectResult.StatusCode == 404;

            Assert.True(isStatusCodeCorrect);

        }

        [Fact]
        public async Task Test_Delete_Method_With_Valid_Id()
        {

            var deleteResult = await testingInstance.Delete(1);
            var getResult = await testingInstance.Get();

            var expectedDevicesCount = DevicesRepositoryMock.GetTestingDevices().Count() - 1;
            var getResultAsOkResult = Assert.IsAssignableFrom<OkObjectResult>(getResult);
            var getResultAsDevicesList = getResultAsOkResult.Value as IQueryable<Device>;
            var devicesCount = getResultAsDevicesList.Count();

            Assert.IsAssignableFrom<OkResult>(deleteResult);

            Assert.Equal(devicesCount, expectedDevicesCount);
        }

    }
}
