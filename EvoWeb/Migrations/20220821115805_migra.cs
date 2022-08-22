using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EvoWeb.Migrations
{
    public partial class migra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Requests");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Requests",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
