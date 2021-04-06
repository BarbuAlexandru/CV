﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PocketPlane.DataAccess;

namespace PocketPlane.DataAccess.Migrations
{
    [DbContext(typeof(PocketPlaneDbContext))]
    [Migration("20200416180607_UpdateAdmin")]
    partial class UpdateAdmin
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PocketPlane.ApplicationLogic.DataModel.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("PocketPlane.ApplicationLogic.DataModel.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CI_Passport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Username")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("PocketPlane.ApplicationLogic.DataModel.Flight", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AdminId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("BusinessPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("EconomyPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("FlightNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("FlightScheduleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PlaneTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("FlightScheduleId");

                    b.HasIndex("PlaneTypeId");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("PocketPlane.ApplicationLogic.DataModel.FlightSchedule", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ArrivalAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArrivalCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ArrivalHour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("DepartureAirport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureCity")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DepartureHour")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FlightSchedules");
                });

            modelBuilder.Entity("PocketPlane.ApplicationLogic.DataModel.PlaneType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CapacityBusiness")
                        .HasColumnType("int");

                    b.Property<int>("CapacityEconomy")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PlaneTypes");
                });

            modelBuilder.Entity("PocketPlane.ApplicationLogic.DataModel.Reservation", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("FlightId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Seat")
                        .HasColumnType("int");

                    b.Property<Guid?>("TicketHolderId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("FlightId");

                    b.HasIndex("TicketHolderId");

                    b.ToTable("Reservations");
                });

            modelBuilder.Entity("PocketPlane.ApplicationLogic.DataModel.TicketHolder", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CI_Passport")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TicketHolders");
                });

            modelBuilder.Entity("PocketPlane.ApplicationLogic.DataModel.Flight", b =>
                {
                    b.HasOne("PocketPlane.ApplicationLogic.DataModel.Admin", "Admin")
                        .WithMany()
                        .HasForeignKey("AdminId");

                    b.HasOne("PocketPlane.ApplicationLogic.DataModel.FlightSchedule", "FlightSchedule")
                        .WithMany()
                        .HasForeignKey("FlightScheduleId");

                    b.HasOne("PocketPlane.ApplicationLogic.DataModel.PlaneType", null)
                        .WithMany("Flight")
                        .HasForeignKey("PlaneTypeId");
                });

            modelBuilder.Entity("PocketPlane.ApplicationLogic.DataModel.Reservation", b =>
                {
                    b.HasOne("PocketPlane.ApplicationLogic.DataModel.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.HasOne("PocketPlane.ApplicationLogic.DataModel.Flight", null)
                        .WithMany("Reservations")
                        .HasForeignKey("FlightId");

                    b.HasOne("PocketPlane.ApplicationLogic.DataModel.TicketHolder", "TicketHolder")
                        .WithMany()
                        .HasForeignKey("TicketHolderId");
                });
#pragma warning restore 612, 618
        }
    }
}
