using DeviceManager.API.Controllers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.API
{
    public static class DependencyInjection
    {

        public static void AddDeviceManagerApi(this IServiceCollection services)
        {
            services
                .AddControllers()
                .AddApplicationPart(typeof(DevicesController).Assembly)
                .AddControllersAsServices();
        }

    }
}
