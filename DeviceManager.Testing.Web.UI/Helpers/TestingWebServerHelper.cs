using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using DeviceManager.Core.Core.Services;
using DeviceManager.Core.Devices.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.TestHost;
using DeviceManager.Web;
using System.IO;

namespace DeviceManager.Testing.Web.UI.Helpers
{


    public static class TestingWebServerHelper
    {

        public const string HOST_URL = "http://localhost:5001/";

        public static IHostBuilder CreateHostBuilder()
        {

            var currentDirectory = Directory.GetCurrentDirectory();
            var contentRootPath = Path.Combine(currentDirectory, "..", "..", "..", "..", "DeviceManager.Web");
            var webRootPath = Path.Combine(currentDirectory, "..", "..", "..", "..", "DeviceManager.Web", "wwwroot");

            var builder = Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(x =>
                {
                    x.UseStartup<Startup>()
                    .UseKestrel()
                    .UseContentRoot(contentRootPath)
                    .UseWebRoot(webRootPath)
                    .UseEnvironment("Development")
                    .UseUrls(HOST_URL);
                })
                .ConfigureServices(services => {
                    var dataContext = services.FirstOrDefault(x => x.ServiceType == typeof(DataContext));
                    services.Remove(dataContext);

                    var devicesRepository = services.FirstOrDefault(x => x.ServiceType == typeof(IDevicesRepository));
                    services.Remove(devicesRepository);

                    services.AddSingleton<IDevicesRepository, TestingDevicesRepository>();
                });

            return builder;
        }

    }
}
