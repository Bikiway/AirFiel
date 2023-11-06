using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirFiel_Mariana_Oliveira.Migrations
{
    public partial class UpdatingFinalTouches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "PassengersSecondClass",
                table: "TicketDetailsTemps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PassengersFirstClass",
                table: "TicketDetailsTemps",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "SeatNumber1Class",
                table: "TicketDetailsTemps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeatsNumber2Class",
                table: "TicketDetailsTemps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "routeId",
                table: "TicketDetailsTemps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PassengersSecondClass",
                table: "TicketDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PassengersFirstClass",
                table: "TicketDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CC",
                table: "TicketDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NIF",
                table: "TicketDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeatNumber1Class",
                table: "TicketDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeatsNumber2Class",
                table: "TicketDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassengersSecondClass",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PassengersFirstClass",
                table: "Ticket",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "CC",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Depart",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NIF",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Return",
                table: "Ticket",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "SeatNumber1Class",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeatsNumber2Class",
                table: "Ticket",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SeatNumber1Class",
                table: "TicketDetailsTemps");

            migrationBuilder.DropColumn(
                name: "SeatsNumber2Class",
                table: "TicketDetailsTemps");

            migrationBuilder.DropColumn(
                name: "routeId",
                table: "TicketDetailsTemps");

            migrationBuilder.DropColumn(
                name: "CC",
                table: "TicketDetails");

            migrationBuilder.DropColumn(
                name: "NIF",
                table: "TicketDetails");

            migrationBuilder.DropColumn(
                name: "SeatNumber1Class",
                table: "TicketDetails");

            migrationBuilder.DropColumn(
                name: "SeatsNumber2Class",
                table: "TicketDetails");

            migrationBuilder.DropColumn(
                name: "CC",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Depart",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "NIF",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Return",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SeatNumber1Class",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "SeatsNumber2Class",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "PassengersSecondClass",
                table: "TicketDetailsTemps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassengersFirstClass",
                table: "TicketDetailsTemps",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassengersSecondClass",
                table: "TicketDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassengersFirstClass",
                table: "TicketDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassengersSecondClass",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PassengersFirstClass",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
