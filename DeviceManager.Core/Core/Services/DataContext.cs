using DeviceManager.Core.Core.Abstractions;
using DeviceManager.Core.Devices.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeviceManager.Core.Core.Services
{
    public class DataContext : DbContext
    {

        public virtual DbSet<Device> Devices { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

    }
}
