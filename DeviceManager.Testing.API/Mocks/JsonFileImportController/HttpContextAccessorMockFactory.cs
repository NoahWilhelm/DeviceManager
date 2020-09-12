using Microsoft.AspNetCore.Http;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.Testing.API.Mocks.DevicesController
{
    public static class HttpContextAccessorMockFactory
    {

        public static IHttpContextAccessor CreateHttpContextAccessorMockWithFormFiles(IEnumerable<IFormFile> files)
        {
            var formCollectionMock = new Mock<IFormCollection>();
            var formFileCollection = files as IFormFileCollection;

            formCollectionMock.Setup(x => x.Files).Returns(formFileCollection);

            var mock = new DevicesControllerHttpContextAccessorMock(formCollectionMock.Object);

            return mock;
        }

    }
}
