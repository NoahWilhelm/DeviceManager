using DeviceManager.API;
using DeviceManager.Core;
using DeviceManager.Core.Core.Services;
using DeviceManager.Core.Devices.Abstractions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DeviceManager.Testing.API.IntegrationTestHelpers
{
    public class TestingWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {

            builder.ConfigureServices(services =>
            {
                services.AddDeviceManager();
                services.AddDeviceManagerApi();
                services.AddControllersWithViews();

                var dataContext = services.FirstOrDefault(x => x.ServiceType == typeof(DataContext));
                services.Remove(dataContext);

                var devicesRepository = services.FirstOrDefault(x => x.ServiceType == typeof(IDevicesRepository));
                services.Remove(devicesRepository);

                services.AddSingleton<IDevicesRepository, TestingDevicesRepository>();

            });

            base.ConfigureWebHost(builder);
        }

        protected override IHostBuilder CreateHostBuilder()
        {

            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x =>
                {
                    x.UseStartup<TestStartup>().UseTestServer();
                });

            return builder;
        }

    }
}
