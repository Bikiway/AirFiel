using Microsoft.EntityFrameworkCore.Migrations;

namespace AirFiel_Mariana_Oliveira.Migrations
{
    public partial class updateRoutesAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_airplanes_FullCapacityId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_RouteDetails_airplanes_fullcapacityId",
                table: "RouteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesDetailsTemps_airplanes_fullcapacityId",
                table: "RoutesDetailsTemps");

            migrationBuilder.RenameColumn(
                name: "fullcapacityId",
                table: "RoutesDetailsTemps",
                newName: "capacity2Id");

            migrationBuilder.RenameIndex(
                name: "IX_RoutesDetailsTemps_fullcapacityId",
                table: "RoutesDetailsTemps",
                newName: "IX_RoutesDetailsTemps_capacity2Id");

            migrationBuilder.RenameColumn(
                name: "fullcapacityId",
                table: "RouteDetails",
                newName: "capacity2Id");

            migrationBuilder.RenameIndex(
                name: "IX_RouteDetails_fullcapacityId",
                table: "RouteDetails",
                newName: "IX_RouteDetails_capacity2Id");

            migrationBuilder.RenameColumn(
                name: "FullCapacityId",
                table: "Route",
                newName: "Capacity2Id");

            migrationBuilder.RenameIndex(
                name: "IX_Route_FullCapacityId",
                table: "Route",
                newName: "IX_Route_Capacity2Id");

            migrationBuilder.AddColumn<int>(
                name: "capacity1Id",
                table: "RoutesDetailsTemps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "capacity1Id",
                table: "RouteDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Capacity1Id",
                table: "Route",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoutesDetailsTemps_capacity1Id",
                table: "RoutesDetailsTemps",
                column: "capacity1Id");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_capacity1Id",
                table: "RouteDetails",
                column: "capacity1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Route_Capacity1Id",
                table: "Route",
                column: "Capacity1Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                name: "IX_RouteDetails_capacity1Id",
                table: "RouteDetails");

            migrationBuilder.DropIndex(
                name: "IX_Route_Capacity1Id",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "capacity1Id",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropColumn(
                name: "capacity1Id",
                table: "RouteDetails");

            migrationBuilder.DropColumn(
                name: "Capacity1Id",
                table: "Route");

            migrationBuilder.RenameColumn(
                name: "capacity2Id",
                table: "RoutesDetailsTemps",
                newName: "fullcapacityId");

            migrationBuilder.RenameIndex(
                name: "IX_RoutesDetailsTemps_capacity2Id",
                table: "RoutesDetailsTemps",
                newName: "IX_RoutesDetailsTemps_fullcapacityId");

            migrationBuilder.RenameColumn(
                name: "capacity2Id",
                table: "RouteDetails",
                newName: "fullcapacityId");

            migrationBuilder.RenameIndex(
                name: "IX_RouteDetails_capacity2Id",
                table: "RouteDetails",
                newName: "IX_RouteDetails_fullcapacityId");

            migrationBuilder.RenameColumn(
                name: "Capacity2Id",
                table: "Route",
                newName: "FullCapacityId");

            migrationBuilder.RenameIndex(
                name: "IX_Route_Capacity2Id",
                table: "Route",
                newName: "IX_Route_FullCapacityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_airplanes_FullCapacityId",
                table: "Route",
                column: "FullCapacityId",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RouteDetails_airplanes_fullcapacityId",
                table: "RouteDetails",
                column: "fullcapacityId",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoutesDetailsTemps_airplanes_fullcapacityId",
                table: "RoutesDetailsTemps",
                column: "fullcapacityId",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
