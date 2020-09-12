using DeviceManager.API.Controllers;
using Microsoft.AspNetCore.Builder;
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

        public static void UseDeviceManagerApi(this IApplicationBuilder app)
        {
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }

    }
}
