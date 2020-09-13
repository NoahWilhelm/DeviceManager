using DeviceManager.API.Controllers;
using DeviceManager.API.Swagger.OperationFilters;
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

            services.AddSwaggerGen(conf => {
                conf.OperationFilter<SwaggerJsonFileOperationFilter>();
            });

        }

        public static void UseDeviceManagerApi(this IApplicationBuilder app)
        {

            app.UseSwagger();

            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DeviceManager API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }

    }
}
