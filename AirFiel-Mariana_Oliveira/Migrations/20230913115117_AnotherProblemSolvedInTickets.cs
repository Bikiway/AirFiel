using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirFiel_Mariana_Oliveira.Migrations
{
    public partial class AnotherProblemSolvedInTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Route_routesId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetails_Route_routesId",
                table: "TicketDetails");

            migrationBuilder.DropIndex(
                name: "IX_TicketDetails_routesId",
                table: "TicketDetails");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_routesId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "HowManyPassengers",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "TicketDetails",
                newName: "LastName");

            migrationBuilder.AlterColumn<int>(
                name: "routesId",
                table: "TicketDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "TicketDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "userId",
                table: "TicketDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "routesId",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeliveryDate",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "capacityReduced1",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "capacityReduced2",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "newUserId",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "TicketDetails");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "TicketDetails");

            migrationBuilder.DropColumn(
                name: "DeliveryDate",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "capacityReduced1",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "capacityReduced2",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "newUserId",
                table: "Ticket");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "TicketDetails",
                newName: "FullName");

            migrationBuilder.AlterColumn<int>(
                name: "routesId",
                table: "TicketDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "routesId",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "HowManyPassengers",
                table: "Ticket",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetails_routesId",
                table: "TicketDetails",
                column: "routesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_routesId",
                table: "Ticket",
                column: "routesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Route_routesId",
                table: "Ticket",
                column: "routesId",
                principalTable: "Route",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetails_Route_routesId",
                table: "TicketDetails",
                column: "routesId",
                principalTable: "Route",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
