using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketPlane.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    AdminID = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientID = table.Column<Guid>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CI_Passport = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "FlightSchedules",
                columns: table => new
                {
                    FlightScheduleID = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    DepartureCity = table.Column<string>(nullable: true),
                    DepartureAirport = table.Column<string>(nullable: true),
                    DepartureHour = table.Column<string>(nullable: true),
                    ArrivalCity = table.Column<string>(nullable: true),
                    ArrivalAirport = table.Column<string>(nullable: true),
                    ArrivalHour = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlightSchedules", x => x.FlightScheduleID);
                });

            migrationBuilder.CreateTable(
                name: "PlaneTypes",
                columns: table => new
                {
                    PlaneTypeID = table.Column<Guid>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    Manufacturer = table.Column<string>(nullable: true),
                    CapacityBusiness = table.Column<int>(nullable: false),
                    CapacityEconomy = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaneTypes", x => x.PlaneTypeID);
                });

            migrationBuilder.CreateTable(
                name: "TicketHolders",
                columns: table => new
                {
                    TicketHolderID = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    CI_Passport = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketHolders", x => x.TicketHolderID);
                });

            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightNO = table.Column<Guid>(nullable: false),
                    AdminID = table.Column<Guid>(nullable: true),
                    FlightScheduleID = table.Column<Guid>(nullable: true),
                    BusinessPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EconomyPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PlaneTypeID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightNO);
                    table.ForeignKey(
                        name: "FK_Flights_Admins_AdminID",
                        column: x => x.AdminID,
                        principalTable: "Admins",
                        principalColumn: "AdminID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_FlightSchedules_FlightScheduleID",
                        column: x => x.FlightScheduleID,
                        principalTable: "FlightSchedules",
                        principalColumn: "FlightScheduleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Flights_PlaneTypes_PlaneTypeID",
                        column: x => x.PlaneTypeID,
                        principalTable: "PlaneTypes",
                        principalColumn: "PlaneTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationID = table.Column<Guid>(nullable: false),
                    ClientID = table.Column<Guid>(nullable: true),
                    TicketHolderID = table.Column<Guid>(nullable: true),
                    Seat = table.Column<int>(nullable: false),
                    FlightNO = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationID);
                    table.ForeignKey(
                        name: "FK_Reservations_Clients_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Clients",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_Flights_FlightNO",
                        column: x => x.FlightNO,
                        principalTable: "Flights",
                        principalColumn: "FlightNO",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservations_TicketHolders_TicketHolderID",
                        column: x => x.TicketHolderID,
                        principalTable: "TicketHolders",
                        principalColumn: "TicketHolderID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Code",
                table: "Admins",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Admins_Username",
                table: "Admins",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_Username",
                table: "Clients",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_AdminID",
                table: "Flights",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_FlightScheduleID",
                table: "Flights",
                column: "FlightScheduleID");

            migrationBuilder.CreateIndex(
                name: "IX_Flights_PlaneTypeID",
                table: "Flights",
                column: "PlaneTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_ClientID",
                table: "Reservations",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FlightNO",
                table: "Reservations",
                column: "FlightNO");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_TicketHolderID",
                table: "Reservations",
                column: "TicketHolderID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "TicketHolders");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "FlightSchedules");

            migrationBuilder.DropTable(
                name: "PlaneTypes");
        }
    }
}
