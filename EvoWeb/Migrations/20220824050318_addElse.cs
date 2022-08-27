using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvoWeb.Migrations
{
    public partial class addElse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHistory",
                table: "Workers",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsHistory",
                table: "Requests",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "DownLink",
                table: "Projects",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHistory",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "IsHistory",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "DownLink",
                table: "Projects");
        }
    }
}
