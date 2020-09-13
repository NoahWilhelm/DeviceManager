﻿// <auto-generated />
using System;
using DeviceManager.Core.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DeviceManager.Core.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("DeviceManager.Core.Devices.Models.Device", b =>
                {
                    b.Property<int>("Entry_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("AdvancedEnvironmentalConditions")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DeviceTypeId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Failsafe")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("InsertInto19InchCabinet")
                        .HasColumnType("INTEGER");

                    b.Property<string>("InstallationPosition")
                        .HasColumnType("TEXT");

                    b.Property<bool>("MotionEnable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("PositionAxisNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RotationAxisNumber")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SimaticCatalog")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("SiplusCatalog")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TempMax")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TempMin")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("TerminalElement")
                        .HasColumnType("INTEGER");

                    b.HasKey("Entry_Id");

                    b.ToTable("Devices");
                });
#pragma warning restore 612, 618
        }
    }
}
