using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvoWeb.Migrations
{
    public partial class addIsActive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Workers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Requests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Projects",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Projects");
        }
    }
}
