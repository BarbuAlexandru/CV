using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketPlane.DataAccess.Migrations
{
    public partial class UpdateAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Admins_AdminID",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_FlightSchedules_FlightScheduleID",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_PlaneTypes_PlaneTypeID",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_ClientID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Flights_FlightNO",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TicketHolders_TicketHolderID",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketHolders",
                table: "TicketHolders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_FlightNO",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaneTypes",
                table: "PlaneTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightSchedules",
                table: "FlightSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flights",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "TicketHolderID",
                table: "TicketHolders");

            migrationBuilder.DropColumn(
                name: "ReservationID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "FlightNO",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "PlaneTypeID",
                table: "PlaneTypes");

            migrationBuilder.DropColumn(
                name: "FlightScheduleID",
                table: "FlightSchedules");

            migrationBuilder.DropColumn(
                name: "ClientID",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "AdminID",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "TicketHolderID",
                table: "Reservations",
                newName: "TicketHolderId");

            migrationBuilder.RenameColumn(
                name: "ClientID",
                table: "Reservations",
                newName: "ClientId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TicketHolderID",
                table: "Reservations",
                newName: "IX_Reservations_TicketHolderId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ClientID",
                table: "Reservations",
                newName: "IX_Reservations_ClientId");

            migrationBuilder.RenameColumn(
                name: "PlaneTypeID",
                table: "Flights",
                newName: "PlaneTypeId");

            migrationBuilder.RenameColumn(
                name: "FlightScheduleID",
                table: "Flights",
                newName: "FlightScheduleId");

            migrationBuilder.RenameColumn(
                name: "AdminID",
                table: "Flights",
                newName: "AdminId");

            migrationBuilder.RenameColumn(
                name: "FlightNO",
                table: "Flights",
                newName: "FlightNo");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_PlaneTypeID",
                table: "Flights",
                newName: "IX_Flights_PlaneTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_FlightScheduleID",
                table: "Flights",
                newName: "IX_Flights_FlightScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_AdminID",
                table: "Flights",
                newName: "IX_Flights_AdminId");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "TicketHolders",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Reservations",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FlightId",
                table: "Reservations",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "PlaneTypes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "FlightSchedules",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "FlightNo",
                table: "Flights",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Flights",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Clients",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "Admins",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketHolders",
                table: "TicketHolders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaneTypes",
                table: "PlaneTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightSchedules",
                table: "FlightSchedules",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flights",
                table: "Flights",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FlightId",
                table: "Reservations",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Admins_AdminId",
                table: "Flights",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_FlightSchedules_FlightScheduleId",
                table: "Flights",
                column: "FlightScheduleId",
                principalTable: "FlightSchedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_PlaneTypes_PlaneTypeId",
                table: "Flights",
                column: "PlaneTypeId",
                principalTable: "PlaneTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_ClientId",
                table: "Reservations",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Flights_FlightId",
                table: "Reservations",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TicketHolders_TicketHolderId",
                table: "Reservations",
                column: "TicketHolderId",
                principalTable: "TicketHolders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Admins_AdminId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_FlightSchedules_FlightScheduleId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Flights_PlaneTypes_PlaneTypeId",
                table: "Flights");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Clients_ClientId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Flights_FlightId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TicketHolders_TicketHolderId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TicketHolders",
                table: "TicketHolders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_FlightId",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlaneTypes",
                table: "PlaneTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FlightSchedules",
                table: "FlightSchedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flights",
                table: "Flights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clients",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Admins",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TicketHolders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "PlaneTypes");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "FlightSchedules");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Flights");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Admins");

            migrationBuilder.RenameColumn(
                name: "TicketHolderId",
                table: "Reservations",
                newName: "TicketHolderID");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "Reservations",
                newName: "ClientID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_TicketHolderId",
                table: "Reservations",
                newName: "IX_Reservations_TicketHolderID");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ClientId",
                table: "Reservations",
                newName: "IX_Reservations_ClientID");

            migrationBuilder.RenameColumn(
                name: "PlaneTypeId",
                table: "Flights",
                newName: "PlaneTypeID");

            migrationBuilder.RenameColumn(
                name: "FlightScheduleId",
                table: "Flights",
                newName: "FlightScheduleID");

            migrationBuilder.RenameColumn(
                name: "FlightNo",
                table: "Flights",
                newName: "FlightNO");

            migrationBuilder.RenameColumn(
                name: "AdminId",
                table: "Flights",
                newName: "AdminID");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_PlaneTypeId",
                table: "Flights",
                newName: "IX_Flights_PlaneTypeID");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_FlightScheduleId",
                table: "Flights",
                newName: "IX_Flights_FlightScheduleID");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_AdminId",
                table: "Flights",
                newName: "IX_Flights_AdminID");

            migrationBuilder.AddColumn<Guid>(
                name: "TicketHolderID",
                table: "TicketHolders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReservationID",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FlightNO",
                table: "Reservations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PlaneTypeID",
                table: "PlaneTypes",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "FlightScheduleID",
                table: "FlightSchedules",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "FlightNO",
                table: "Flights",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ClientID",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AdminID",
                table: "Admins",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_TicketHolders",
                table: "TicketHolders",
                column: "TicketHolderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservations",
                table: "Reservations",
                column: "ReservationID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlaneTypes",
                table: "PlaneTypes",
                column: "PlaneTypeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FlightSchedules",
                table: "FlightSchedules",
                column: "FlightScheduleID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flights",
                table: "Flights",
                column: "FlightNO");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clients",
                table: "Clients",
                column: "ClientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Admins",
                table: "Admins",
                column: "AdminID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_FlightNO",
                table: "Reservations",
                column: "FlightNO");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Admins_AdminID",
                table: "Flights",
                column: "AdminID",
                principalTable: "Admins",
                principalColumn: "AdminID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_FlightSchedules_FlightScheduleID",
                table: "Flights",
                column: "FlightScheduleID",
                principalTable: "FlightSchedules",
                principalColumn: "FlightScheduleID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_PlaneTypes_PlaneTypeID",
                table: "Flights",
                column: "PlaneTypeID",
                principalTable: "PlaneTypes",
                principalColumn: "PlaneTypeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Clients_ClientID",
                table: "Reservations",
                column: "ClientID",
                principalTable: "Clients",
                principalColumn: "ClientID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Flights_FlightNO",
                table: "Reservations",
                column: "FlightNO",
                principalTable: "Flights",
                principalColumn: "FlightNO",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TicketHolders_TicketHolderID",
                table: "Reservations",
                column: "TicketHolderID",
                principalTable: "TicketHolders",
                principalColumn: "TicketHolderID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
