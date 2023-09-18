using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirFiel_Mariana_Oliveira.Migrations
{
    public partial class updateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_airplains_AspNetUsers_usersId",
                table: "airplains");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteDetails_airplains_airplanesId",
                table: "RouteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteDetails_City_citysId",
                table: "RouteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteDetails_Employee_employeesId",
                table: "RouteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesDetailsTemps_airplains_airplanesId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesDetailsTemps_City_citiesId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesDetailsTemps_Employee_employeesId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_airplains",
                table: "airplains");

            migrationBuilder.DropColumn(
                name: "TicketLetter",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "TicketNumber",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employee");

            migrationBuilder.RenameTable(
                name: "airplains",
                newName: "airplanes");

            migrationBuilder.RenameColumn(
                name: "employeesId",
                table: "RoutesDetailsTemps",
                newName: "pilotEmployeesId");

            migrationBuilder.RenameColumn(
                name: "citiesId",
                table: "RoutesDetailsTemps",
                newName: "originCitiesId");

            migrationBuilder.RenameColumn(
                name: "TravelQuantity",
                table: "RoutesDetailsTemps",
                newName: "TravelsPerMonth");

            migrationBuilder.RenameIndex(
                name: "IX_RoutesDetailsTemps_employeesId",
                table: "RoutesDetailsTemps",
                newName: "IX_RoutesDetailsTemps_pilotEmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_RoutesDetailsTemps_citiesId",
                table: "RoutesDetailsTemps",
                newName: "IX_RoutesDetailsTemps_originCitiesId");

            migrationBuilder.RenameColumn(
                name: "employeesId",
                table: "RouteDetails",
                newName: "pilotEmployeesId");

            migrationBuilder.RenameColumn(
                name: "citysId",
                table: "RouteDetails",
                newName: "originCitiesId");

            migrationBuilder.RenameColumn(
                name: "TravelQuantity",
                table: "RouteDetails",
                newName: "TravelsPerMonth");

            migrationBuilder.RenameIndex(
                name: "IX_RouteDetails_employeesId",
                table: "RouteDetails",
                newName: "IX_RouteDetails_pilotEmployeesId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteDetails_citysId",
                table: "RouteDetails",
                newName: "IX_RouteDetails_originCitiesId");

            migrationBuilder.RenameColumn(
                name: "FullPrice",
                table: "Route",
                newName: "Discounts");

            migrationBuilder.RenameIndex(
                name: "IX_airplains_usersId",
                table: "airplanes",
                newName: "IX_airplanes_usersId");

            migrationBuilder.AddColumn<string>(
                name: "ClientFirstName",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientLastName",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HowManyPassengers",
                table: "Ticket",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "routesId",
                table: "Ticket",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usersId",
                table: "Ticket",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "FullPrice",
                table: "RoutesDetailsTemps",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "coPilotEmployeesId",
                table: "RoutesDetailsTemps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "destinationCitiesId",
                table: "RoutesDetailsTemps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userId",
                table: "RoutesDetailsTemps",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "coPilotEmployeesId",
                table: "RouteDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "destinationCitiesId",
                table: "RouteDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usersId",
                table: "Route",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_airplanes",
                table: "airplanes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TicketDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    routesId = table.Column<int>(type: "int", nullable: true),
                    QuantityOfPassengers = table.Column<int>(type: "int", nullable: false),
                    PricePerTicket = table.Column<double>(type: "float", nullable: false),
                    TicketsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketDetails_Route_routesId",
                        column: x => x.routesId,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketDetails_Ticket_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Ticket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketDetailsTemps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CC = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    NIF = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passengers = table.Column<int>(type: "int", nullable: false),
                    IdaEVolta = table.Column<bool>(type: "bit", nullable: false),
                    PricePerTicket = table.Column<double>(type: "float", nullable: false),
                    routesIdId = table.Column<int>(type: "int", nullable: true),
                    userId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketDetailsTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketDetailsTemps_AspNetUsers_userId",
                        column: x => x.userId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketDetailsTemps_Route_routesIdId",
                        column: x => x.routesIdId,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_routesId",
                table: "Ticket",
                column: "routesId");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_usersId",
                table: "Ticket",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutesDetailsTemps_coPilotEmployeesId",
                table: "RoutesDetailsTemps",
                column: "coPilotEmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutesDetailsTemps_destinationCitiesId",
                table: "RoutesDetailsTemps",
                column: "destinationCitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutesDetailsTemps_userId",
                table: "RoutesDetailsTemps",
                column: "userId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_coPilotEmployeesId",
                table: "RouteDetails",
                column: "coPilotEmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_destinationCitiesId",
                table: "RouteDetails",
                column: "destinationCitiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_usersId",
                table: "Route",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetails_routesId",
                table: "TicketDetails",
                column: "routesId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetails_TicketsId",
                table: "TicketDetails",
                column: "TicketsId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetailsTemps_routesIdId",
                table: "TicketDetailsTemps",
                column: "routesIdId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetailsTemps_userId",
                table: "TicketDetailsTemps",
                column: "userId");

            migrationBuilder.AddForeignKey(
                name: "FK_airplanes_AspNetUsers_usersId",
                table: "airplanes",
                column: "usersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_AspNetUsers_usersId",
                table: "Route",
                column: "usersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteDetails_airplanes_airplanesId",
                table: "RouteDetails",
                column: "airplanesId",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteDetails_City_destinationCitiesId",
                table: "RouteDetails",
                column: "destinationCitiesId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteDetails_City_originCitiesId",
                table: "RouteDetails",
                column: "originCitiesId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteDetails_Employee_coPilotEmployeesId",
                table: "RouteDetails",
                column: "coPilotEmployeesId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteDetails_Employee_pilotEmployeesId",
                table: "RouteDetails",
                column: "pilotEmployeesId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesDetailsTemps_airplanes_airplanesId",
                table: "RoutesDetailsTemps",
                column: "airplanesId",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesDetailsTemps_AspNetUsers_userId",
                table: "RoutesDetailsTemps",
                column: "userId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesDetailsTemps_City_destinationCitiesId",
                table: "RoutesDetailsTemps",
                column: "destinationCitiesId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesDetailsTemps_City_originCitiesId",
                table: "RoutesDetailsTemps",
                column: "originCitiesId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesDetailsTemps_Employee_coPilotEmployeesId",
                table: "RoutesDetailsTemps",
                column: "coPilotEmployeesId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesDetailsTemps_Employee_pilotEmployeesId",
                table: "RoutesDetailsTemps",
                column: "pilotEmployeesId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_AspNetUsers_usersId",
                table: "Ticket",
                column: "usersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Route_routesId",
                table: "Ticket",
                column: "routesId",
                principalTable: "Route",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_airplanes_AspNetUsers_usersId",
                table: "airplanes");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_AspNetUsers_usersId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteDetails_airplanes_airplanesId",
                table: "RouteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteDetails_City_destinationCitiesId",
                table: "RouteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteDetails_City_originCitiesId",
                table: "RouteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteDetails_Employee_coPilotEmployeesId",
                table: "RouteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteDetails_Employee_pilotEmployeesId",
                table: "RouteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesDetailsTemps_airplanes_airplanesId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesDetailsTemps_AspNetUsers_userId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesDetailsTemps_City_destinationCitiesId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesDetailsTemps_City_originCitiesId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesDetailsTemps_Employee_coPilotEmployeesId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesDetailsTemps_Employee_pilotEmployeesId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_AspNetUsers_usersId",
                table: "Ticket");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Route_routesId",
                table: "Ticket");

            migrationBuilder.DropTable(
                name: "TicketDetails");

            migrationBuilder.DropTable(
                name: "TicketDetailsTemps");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_routesId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_Ticket_usersId",
                table: "Ticket");

            migrationBuilder.DropIndex(
                name: "IX_RoutesDetailsTemps_coPilotEmployeesId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropIndex(
                name: "IX_RoutesDetailsTemps_destinationCitiesId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropIndex(
                name: "IX_RoutesDetailsTemps_userId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropIndex(
                name: "IX_RouteDetails_coPilotEmployeesId",
                table: "RouteDetails");

            migrationBuilder.DropIndex(
                name: "IX_RouteDetails_destinationCitiesId",
                table: "RouteDetails");

            migrationBuilder.DropIndex(
                name: "IX_Route_usersId",
                table: "Route");

            migrationBuilder.DropPrimaryKey(
                name: "PK_airplanes",
                table: "airplanes");

            migrationBuilder.DropColumn(
                name: "ClientFirstName",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "ClientLastName",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "HowManyPassengers",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "routesId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "usersId",
                table: "Ticket");

            migrationBuilder.DropColumn(
                name: "FullPrice",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropColumn(
                name: "coPilotEmployeesId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropColumn(
                name: "destinationCitiesId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropColumn(
                name: "userId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropColumn(
                name: "coPilotEmployeesId",
                table: "RouteDetails");

            migrationBuilder.DropColumn(
                name: "destinationCitiesId",
                table: "RouteDetails");

            migrationBuilder.DropColumn(
                name: "usersId",
                table: "Route");

            migrationBuilder.RenameTable(
                name: "airplanes",
                newName: "airplains");

            migrationBuilder.RenameColumn(
                name: "pilotEmployeesId",
                table: "RoutesDetailsTemps",
                newName: "employeesId");

            migrationBuilder.RenameColumn(
                name: "originCitiesId",
                table: "RoutesDetailsTemps",
                newName: "citiesId");

            migrationBuilder.RenameColumn(
                name: "TravelsPerMonth",
                table: "RoutesDetailsTemps",
                newName: "TravelQuantity");

            migrationBuilder.RenameIndex(
                name: "IX_RoutesDetailsTemps_pilotEmployeesId",
                table: "RoutesDetailsTemps",
                newName: "IX_RoutesDetailsTemps_employeesId");

            migrationBuilder.RenameIndex(
                name: "IX_RoutesDetailsTemps_originCitiesId",
                table: "RoutesDetailsTemps",
                newName: "IX_RoutesDetailsTemps_citiesId");

            migrationBuilder.RenameColumn(
                name: "pilotEmployeesId",
                table: "RouteDetails",
                newName: "employeesId");

            migrationBuilder.RenameColumn(
                name: "originCitiesId",
                table: "RouteDetails",
                newName: "citysId");

            migrationBuilder.RenameColumn(
                name: "TravelsPerMonth",
                table: "RouteDetails",
                newName: "TravelQuantity");

            migrationBuilder.RenameIndex(
                name: "IX_RouteDetails_pilotEmployeesId",
                table: "RouteDetails",
                newName: "IX_RouteDetails_employeesId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteDetails_originCitiesId",
                table: "RouteDetails",
                newName: "IX_RouteDetails_citysId");

            migrationBuilder.RenameColumn(
                name: "Discounts",
                table: "Route",
                newName: "FullPrice");

            migrationBuilder.RenameIndex(
                name: "IX_airplanes_usersId",
                table: "airplains",
                newName: "IX_airplains_usersId");

            migrationBuilder.AddColumn<string>(
                name: "TicketLetter",
                table: "Ticket",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TicketNumber",
                table: "Ticket",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employee",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_airplains",
                table: "airplains",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_airplains_AspNetUsers_usersId",
                table: "airplains",
                column: "usersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteDetails_airplains_airplanesId",
                table: "RouteDetails",
                column: "airplanesId",
                principalTable: "airplains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteDetails_City_citysId",
                table: "RouteDetails",
                column: "citysId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteDetails_Employee_employeesId",
                table: "RouteDetails",
                column: "employeesId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesDetailsTemps_airplains_airplanesId",
                table: "RoutesDetailsTemps",
                column: "airplanesId",
                principalTable: "airplains",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesDetailsTemps_City_citiesId",
                table: "RoutesDetailsTemps",
                column: "citiesId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesDetailsTemps_Employee_employeesId",
                table: "RoutesDetailsTemps",
                column: "employeesId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
