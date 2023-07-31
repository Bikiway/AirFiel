using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AirFiel_Mariana_Oliveira.Migrations
{
    public partial class LofOfImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsersId",
                table: "City",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUserProfile",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "usersId",
                table: "airplains",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Route",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AirplaneName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoPilot = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullPrice = table.Column<double>(type: "float", nullable: false),
                    Depart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Return = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Route", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoutesDetailsTemps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    airplanesId = table.Column<int>(type: "int", nullable: true),
                    citiesId = table.Column<int>(type: "int", nullable: true),
                    employeesId = table.Column<int>(type: "int", nullable: true),
                    TravelQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoutesDetailsTemps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoutesDetailsTemps_airplains_airplanesId",
                        column: x => x.airplanesId,
                        principalTable: "airplains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoutesDetailsTemps_City_citiesId",
                        column: x => x.citiesId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoutesDetailsTemps_Employee_employeesId",
                        column: x => x.employeesId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RouteDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    airplanesId = table.Column<int>(type: "int", nullable: true),
                    employeesId = table.Column<int>(type: "int", nullable: true),
                    citysId = table.Column<int>(type: "int", nullable: true),
                    FullPrice = table.Column<double>(type: "float", nullable: false),
                    TravelQuantity = table.Column<int>(type: "int", nullable: false),
                    RoutesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteDetails_airplains_airplanesId",
                        column: x => x.airplanesId,
                        principalTable: "airplains",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RouteDetails_City_citysId",
                        column: x => x.citysId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RouteDetails_Employee_employeesId",
                        column: x => x.employeesId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RouteDetails_Route_RoutesId",
                        column: x => x.RoutesId,
                        principalTable: "Route",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UsersId",
                table: "Employee",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_City_UsersId",
                table: "City",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_airplains_usersId",
                table: "airplains",
                column: "usersId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_airplanesId",
                table: "RouteDetails",
                column: "airplanesId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_citysId",
                table: "RouteDetails",
                column: "citysId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_employeesId",
                table: "RouteDetails",
                column: "employeesId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_RoutesId",
                table: "RouteDetails",
                column: "RoutesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutesDetailsTemps_airplanesId",
                table: "RoutesDetailsTemps",
                column: "airplanesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutesDetailsTemps_citiesId",
                table: "RoutesDetailsTemps",
                column: "citiesId");

            migrationBuilder.CreateIndex(
                name: "IX_RoutesDetailsTemps_employeesId",
                table: "RoutesDetailsTemps",
                column: "employeesId");

            migrationBuilder.AddForeignKey(
                name: "FK_airplains_AspNetUsers_usersId",
                table: "airplains",
                column: "usersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_City_AspNetUsers_UsersId",
                table: "City",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AspNetUsers_UsersId",
                table: "Employee",
                column: "UsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_airplains_AspNetUsers_usersId",
                table: "airplains");

            migrationBuilder.DropForeignKey(
                name: "FK_City_AspNetUsers_UsersId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AspNetUsers_UsersId",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "RouteDetails");

            migrationBuilder.DropTable(
                name: "RoutesDetailsTemps");

            migrationBuilder.DropTable(
                name: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Employee_UsersId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_City_UsersId",
                table: "City");

            migrationBuilder.DropIndex(
                name: "IX_airplains_usersId",
                table: "airplains");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "ImageUserProfile",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "usersId",
                table: "airplains");
        }
    }
}
