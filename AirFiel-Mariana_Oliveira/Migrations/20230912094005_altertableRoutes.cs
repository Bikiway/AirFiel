using Microsoft.EntityFrameworkCore.Migrations;

namespace AirFiel_Mariana_Oliveira.Migrations
{
    public partial class altertableRoutes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirplaneName",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "CoPilot",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "Destination",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "FullCapacity",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "Origin",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "Pilot",
                table: "Route");

            migrationBuilder.AddColumn<int>(
                name: "AirplaneNameId",
                table: "Route",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoPilotId",
                table: "Route",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DestinationId",
                table: "Route",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FullCapacityId",
                table: "Route",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OriginId",
                table: "Route",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PilotId",
                table: "Route",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Route_AirplaneNameId",
                table: "Route",
                column: "AirplaneNameId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_CoPilotId",
                table: "Route",
                column: "CoPilotId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_DestinationId",
                table: "Route",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_FullCapacityId",
                table: "Route",
                column: "FullCapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_OriginId",
                table: "Route",
                column: "OriginId");

            migrationBuilder.CreateIndex(
                name: "IX_Route_PilotId",
                table: "Route",
                column: "PilotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Route_airplanes_AirplaneNameId",
                table: "Route",
                column: "AirplaneNameId",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_airplanes_FullCapacityId",
                table: "Route",
                column: "FullCapacityId",
                principalTable: "airplanes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_City_DestinationId",
                table: "Route",
                column: "DestinationId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_City_OriginId",
                table: "Route",
                column: "OriginId",
                principalTable: "City",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Employee_CoPilotId",
                table: "Route",
                column: "CoPilotId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Route_Employee_PilotId",
                table: "Route",
                column: "PilotId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Route_airplanes_AirplaneNameId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_airplanes_FullCapacityId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_City_DestinationId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_City_OriginId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_Employee_CoPilotId",
                table: "Route");

            migrationBuilder.DropForeignKey(
                name: "FK_Route_Employee_PilotId",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_AirplaneNameId",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_CoPilotId",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_DestinationId",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_FullCapacityId",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_OriginId",
                table: "Route");

            migrationBuilder.DropIndex(
                name: "IX_Route_PilotId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "AirplaneNameId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "CoPilotId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "DestinationId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "FullCapacityId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "OriginId",
                table: "Route");

            migrationBuilder.DropColumn(
                name: "PilotId",
                table: "Route");

            migrationBuilder.AddColumn<string>(
                name: "AirplaneName",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CoPilot",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Destination",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FullCapacity",
                table: "Route",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Origin",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pilot",
                table: "Route",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
