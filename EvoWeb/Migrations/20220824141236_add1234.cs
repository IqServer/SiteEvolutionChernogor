using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvoWeb.Migrations
{
    public partial class add1234 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHistory",
                table: "Workers");

            migrationBuilder.RenameColumn(
                name: "IsHistory",
                table: "Requests",
                newName: "IsActive");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsActive",
                table: "Requests",
                newName: "IsHistory");

            migrationBuilder.AddColumn<bool>(
                name: "IsHistory",
                table: "Workers",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
