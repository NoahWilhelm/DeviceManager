using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.Testing.API.Mocks.DevicesController
{
    public class DevicesControllerHttpContextAccessorMock : IHttpContextAccessor
    {
        public HttpContext HttpContext { get; set; }

        //public DevicesControllerHttpContextAccessorMock()
        //{
        //    HttpContext = new DevicesControllerHttpContextMock();
        //}

        public DevicesControllerHttpContextAccessorMock(IFormCollection formCollection)
        {
            HttpContext = new DevicesControllerHttpContextMock(formCollection);
        }

    }
}
