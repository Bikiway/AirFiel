using Microsoft.EntityFrameworkCore.Migrations;

namespace AirFiel_Mariana_Oliveira.Migrations
{
    public partial class Routes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstClass",
                table: "airplains");

            migrationBuilder.DropColumn(
                name: "SecondClass",
                table: "airplains");

            migrationBuilder.AddColumn<int>(
                name: "HowManyClasses",
                table: "airplains",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HowManyClasses",
                table: "airplains");

            migrationBuilder.AddColumn<string>(
                name: "FirstClass",
                table: "airplains",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SecondClass",
                table: "airplains",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
