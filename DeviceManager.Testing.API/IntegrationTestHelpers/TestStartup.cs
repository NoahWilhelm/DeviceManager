using DeviceManager.API;
using DeviceManager.Core;
using DeviceManager.Core.Core.Services;
using DeviceManager.Core.Devices.Abstractions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceManager.Testing.API.IntegrationTestHelpers
{
    public class TestStartup
    {
        public TestStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDeviceManager();
            services.AddDeviceManagerApi();

            services.AddControllersWithViews();

            var dataContext = services.FirstOrDefault(x => x.ServiceType == typeof(DataContext));
            services.Remove(dataContext);

            var devicesRepository = services.FirstOrDefault(x => x.ServiceType == typeof(IDevicesRepository));
            services.Remove(devicesRepository);

            services.AddSingleton<IDevicesRepository, TestingDevicesRepository>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
