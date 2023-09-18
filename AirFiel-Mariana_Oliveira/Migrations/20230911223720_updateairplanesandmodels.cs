using Microsoft.EntityFrameworkCore.Migrations;

namespace AirFiel_Mariana_Oliveira.Migrations
{
    public partial class updateairplanesandmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "fullcapacityId",
                table: "RoutesDetailsTemps",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "fullcapacityId",
                table: "RouteDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FullCapacity",
                table: "Route",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity2",
                table: "airplanes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Capacity1",
                table: "airplanes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RoutesDetailsTemps_fullcapacityId",
                table: "RoutesDetailsTemps",
                column: "fullcapacityId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteDetails_fullcapacityId",
                table: "RouteDetails",
                column: "fullcapacityId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RouteDetails_airplanes_fullcapacityId",
                table: "RouteDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_RoutesDetailsTemps_airplanes_fullcapacityId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropIndex(
                name: "IX_RoutesDetailsTemps_fullcapacityId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropIndex(
                name: "IX_RouteDetails_fullcapacityId",
                table: "RouteDetails");

            migrationBuilder.DropColumn(
                name: "fullcapacityId",
                table: "RoutesDetailsTemps");

            migrationBuilder.DropColumn(
                name: "fullcapacityId",
                table: "RouteDetails");

            migrationBuilder.DropColumn(
                name: "FullCapacity",
                table: "Route");

            migrationBuilder.AlterColumn<string>(
                name: "Capacity2",
                table: "airplanes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Capacity1",
                table: "airplanes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
