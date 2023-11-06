using Microsoft.EntityFrameworkCore.Migrations;

namespace AirFiel_Mariana_Oliveira.Migrations
{
    public partial class UpdateTicketsAndViews : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PassengersFirstClass",
                table: "TicketDetailsTemps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassengersSecondClass",
                table: "TicketDetailsTemps",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IdaEVolta",
                table: "TicketDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PassengersFirstClass",
                table: "TicketDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassengersSecondClass",
                table: "TicketDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PassengersFirstClass",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PassengersSecondClass",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PassengersFirstClass",
                table: "TicketDetailsTemps");

            migrationBuilder.DropColumn(
                name: "PassengersSecondClass",
                table: "TicketDetailsTemps");

            migrationBuilder.DropColumn(
                name: "IdaEVolta",
                table: "TicketDetails");

            migrationBuilder.DropColumn(
                name: "PassengersFirstClass",
                table: "TicketDetails");

            migrationBuilder.DropColumn(
                name: "PassengersSecondClass",
                table: "TicketDetails");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "PassengersFirstClass",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "PassengersSecondClass",
                table: "Ticket");
        }
    }
}
