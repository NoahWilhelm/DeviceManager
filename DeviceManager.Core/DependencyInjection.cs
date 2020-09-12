using DeviceManager.Core.Core.Abstractions;
using DeviceManager.Core.Core.Services;
using DeviceManager.Core.DeviceImport.Abstractions;
using DeviceManager.Core.DeviceImport.Services;
using DeviceManager.Core.Devices.Abstractions;
using DeviceManager.Core.Devices.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceManager.Core
{
    public static class DependencyInjection
    {

        public static void AddDeviceManager(this IServiceCollection services)
        {
            services.AddDbContext<DataContext>(x => x.UseSqlite("Data Source=Data.db"));
            services.AddScoped<IDevicesRepository, DevicesRepository>();
            services.AddScoped<IDevicesFileImportService, DevicesFileImportService>();
            services.AddHttpContextAccessor();
        }

    }
}
