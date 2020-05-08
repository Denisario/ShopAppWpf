using Microsoft.EntityFrameworkCore.Migrations;

namespace PartShop.EntityFramework.Migrations
{
    public partial class rework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasPartInProvider",
                table: "PartProviders");

            migrationBuilder.AddColumn<int>(
                name: "TotalParts",
                table: "PartProviders",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalParts",
                table: "PartProviders");

            migrationBuilder.AddColumn<bool>(
                name: "HasPartInProvider",
                table: "PartProviders",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
