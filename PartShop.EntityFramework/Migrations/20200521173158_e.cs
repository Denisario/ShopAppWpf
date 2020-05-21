using Microsoft.EntityFrameworkCore.Migrations;

namespace PartShop.EntityFramework.Migrations
{
    public partial class e : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Accounts_AccountId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Orders",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AccountId",
                table: "Orders",
                newName: "IX_Orders_account_id");

            migrationBuilder.AlterColumn<int>(
                name: "account_id",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "pin",
                table: "Cards",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Accounts_account_id",
                table: "Orders",
                column: "account_id",
                principalTable: "Accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Accounts_account_id",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "Orders",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_account_id",
                table: "Orders",
                newName: "IX_Orders_AccountId");

            migrationBuilder.AlterColumn<int>(
                name: "AccountId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "pin",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Accounts_AccountId",
                table: "Orders",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
