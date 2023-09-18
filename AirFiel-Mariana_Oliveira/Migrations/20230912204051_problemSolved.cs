using Microsoft.EntityFrameworkCore.Migrations;

namespace AirFiel_Mariana_Oliveira.Migrations
{
    public partial class problemSolved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_airplanes_Capacity1Id",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_airplanes_Capacity2Id",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteDetails_airplanes_capacity1Id",
                table: "RouteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteDetails_airplanes_capacity2Id",
                table: "RouteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesDetailsTemps_airplanes_capacity1Id",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesDetailsTemps_airplanes_capacity2Id",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropIndex(
                name: "IX_RoutesDetailsTemps_capacity1Id",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropIndex(
                name: "IX_RoutesDetailsTemps_capacity2Id",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropIndex(
                name: "IX_RouteDetails_capacity1Id",
                table: "RouteDetails");

            migrationBuilder.DropIndex(
                name: "IX_RouteDetails_capacity2Id",
                table: "RouteDetails");

            migrationBuilder.DropIndex(
                name: "IX_Route_Capacity1Id",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_Capacity2Id",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "capacity1Id",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropColumn(
                name: "capacity2Id",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropColumn(
                name: "capacity1Id",
                table: "RouteDetails");

            migrationBuilder.DropColumn(
                name: "capacity2Id",
                table: "RouteDetails");

            migrationBuilder.DropColumn(
                name: "Capacity1Id",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "Capacity2Id",
                table: "Route");

            migrationBuilder.AddColumn<int>(
                name: "Capacity1",
                table: "Route",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Capacity2",
                table: "Route",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Capacity1",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "Capacity2",
                table: "Route");

            migrationBuilder.AddColumn<int>(
                name: "capacity1Id",
                table: "RoutesDetailsTemps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "capacity2Id",
                table: "RoutesDetailsTemps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "capacity1Id",
                table: "RouteDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "capacity2Id",
                table: "RouteDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity1Id",
                table: "Route",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity2Id",
                table: "Route",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoutesDetailsTemps_capacity1Id",
                table: "RoutesDetailsTemps",
                column: "capacity1Id");

            migrationBuilder.CreateIndex(
                name: "IX_RoutesDetailsTemps_capacity2Id",
                table: "RoutesDetailsTemps",
                column: "capacity2Id");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_capacity1Id",
                table: "RouteDetails",
                column: "capacity1Id");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_capacity2Id",
                table: "RouteDetails",
                column: "capacity2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Route_Capacity1Id",
                table: "Route",
                column: "Capacity1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Route_Capacity2Id",
                table: "Route",
                column: "Capacity2Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_airplanes_Capacity1Id",
                table: "Route",
                column: "Capacity1Id",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_airplanes_Capacity2Id",
                table: "Route",
                column: "Capacity2Id",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteDetails_airplanes_capacity1Id",
                table: "RouteDetails",
                column: "capacity1Id",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteDetails_airplanes_capacity2Id",
                table: "RouteDetails",
                column: "capacity2Id",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesDetailsTemps_airplanes_capacity1Id",
                table: "RoutesDetailsTemps",
                column: "capacity1Id",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesDetailsTemps_airplanes_capacity2Id",
                table: "RoutesDetailsTemps",
                column: "capacity2Id",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
