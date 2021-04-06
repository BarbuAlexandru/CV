using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketPlane.DataAccess.Migrations
{
    public partial class UpdateFlightSchedule : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "FlightSchedules");

            migrationBuilder.AddColumn<DateTime>(
                name: "ArrivalDate",
                table: "FlightSchedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DepartureDate",
                table: "FlightSchedules",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArrivalDate",
                table: "FlightSchedules");

            migrationBuilder.DropColumn(
                name: "DepartureDate",
                table: "FlightSchedules");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "FlightSchedules",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
