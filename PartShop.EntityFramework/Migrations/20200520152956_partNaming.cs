using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PartShop.EntityFramework.Migrations
{
    public partial class partNaming : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Orders_Id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_CarParts_Cars_CarId",
                table: "CarParts");

            migrationBuilder.DropForeignKey(
                name: "FK_CarParts_Parts_PartId",
                table: "CarParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Accounts_AccountId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderParts_Orders_OrderId",
                table: "OrderParts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderParts_Parts_PartId",
                table: "OrderParts");

            migrationBuilder.DropForeignKey(
                name: "FK_PartProviders_Parts_PartId",
                table: "PartProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_PartProviders_Providers_ProviderId",
                table: "PartProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                table: "Carts");

            migrationBuilder.RenameTable(
                name: "Carts",
                newName: "Cart");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Providers",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Providers",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Parts",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Parts",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Parts",
                newName: "color");

            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Parts",
                newName: "category");

            migrationBuilder.RenameColumn(
                name: "Article",
                table: "Parts",
                newName: "article");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Parts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "TotalParts",
                table: "PartProviders",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "PartCost",
                table: "PartProviders",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "PartProviders",
                newName: "provider_id");

            migrationBuilder.RenameColumn(
                name: "PartId",
                table: "PartProviders",
                newName: "part_id");

            migrationBuilder.RenameIndex(
                name: "IX_PartProviders_ProviderId",
                table: "PartProviders",
                newName: "IX_PartProviders_provider_id");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Orders",
                newName: "status");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "OrderCreationTime",
                table: "Orders",
                newName: "creation_time");

            migrationBuilder.RenameColumn(
                name: "FinishDate",
                table: "Orders",
                newName: "finish_time");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "OrderParts",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "OrderParts",
                newName: "provider_id");

            migrationBuilder.RenameColumn(
                name: "AmountPart",
                table: "OrderParts",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrderParts",
                newName: "order_id");

            migrationBuilder.RenameColumn(
                name: "PartId",
                table: "OrderParts",
                newName: "part_id");

            migrationBuilder.RenameIndex(
                name: "IX_OrderParts_OrderId",
                table: "OrderParts",
                newName: "IX_OrderParts_order_id");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Cars",
                newName: "model");

            migrationBuilder.RenameColumn(
                name: "Mark",
                table: "Cars",
                newName: "mark");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cars",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FuelType",
                table: "Cars",
                newName: "fuel_type");

            migrationBuilder.RenameColumn(
                name: "CreationYear",
                table: "Cars",
                newName: "creation_year");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "CarParts",
                newName: "car_id");

            migrationBuilder.RenameColumn(
                name: "PartId",
                table: "CarParts",
                newName: "part_id");

            migrationBuilder.RenameIndex(
                name: "IX_CarParts_CarId",
                table: "CarParts",
                newName: "IX_CarParts_car_id");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Cards",
                newName: "balance");

            migrationBuilder.RenameColumn(
                name: "Attempts",
                table: "Cards",
                newName: "attempts");

            migrationBuilder.RenameColumn(
                name: "PinCode",
                table: "Cards",
                newName: "pin");

            migrationBuilder.RenameColumn(
                name: "FinishDate",
                table: "Cards",
                newName: "finish_date");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Cards",
                newName: "creation_date");

            migrationBuilder.RenameColumn(
                name: "CardNumber",
                table: "Cards",
                newName: "number");

            migrationBuilder.RenameColumn(
                name: "Street",
                table: "Address",
                newName: "street");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Address",
                newName: "city");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Address",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "House",
                table: "Address",
                newName: "house_number");

            migrationBuilder.RenameColumn(
                name: "Apartament",
                table: "Address",
                newName: "apartament_number");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Accounts",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Accounts",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Accounts",
                newName: "balance");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Accounts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserRole",
                table: "Accounts",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Accounts",
                newName: "pass");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Accounts",
                newName: "creation_date");

            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Cart",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Cart",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ProviderId",
                table: "Cart",
                newName: "provider_id");

            migrationBuilder.RenameColumn(
                name: "PartId",
                table: "Cart",
                newName: "part_id");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "Cart",
                newName: "car_id");

            migrationBuilder.RenameColumn(
                name: "AccountId",
                table: "Cart",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_AccountId",
                table: "Cart",
                newName: "IX_Cart_account_id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "finish_date",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cart",
                table: "Cart",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Orders_id",
                table: "Address",
                column: "id",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarParts_Cars_car_id",
                table: "CarParts",
                column: "car_id",
                principalTable: "Cars",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarParts_Parts_part_id",
                table: "CarParts",
                column: "part_id",
                principalTable: "Parts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Accounts_account_id",
                table: "Cart",
                column: "account_id",
                principalTable: "Accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderParts_Orders_order_id",
                table: "OrderParts",
                column: "order_id",
                principalTable: "Orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderParts_Parts_part_id",
                table: "OrderParts",
                column: "part_id",
                principalTable: "Parts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartProviders_Parts_part_id",
                table: "PartProviders",
                column: "part_id",
                principalTable: "Parts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartProviders_Providers_provider_id",
                table: "PartProviders",
                column: "provider_id",
                principalTable: "Providers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Address_Orders_id",
                table: "Address");

            migrationBuilder.DropForeignKey(
                name: "FK_CarParts_Cars_car_id",
                table: "CarParts");

            migrationBuilder.DropForeignKey(
                name: "FK_CarParts_Parts_part_id",
                table: "CarParts");

            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Accounts_account_id",
                table: "Cart");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderParts_Orders_order_id",
                table: "OrderParts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderParts_Parts_part_id",
                table: "OrderParts");

            migrationBuilder.DropForeignKey(
                name: "FK_PartProviders_Parts_part_id",
                table: "PartProviders");

            migrationBuilder.DropForeignKey(
                name: "FK_PartProviders_Providers_provider_id",
                table: "PartProviders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cart",
                table: "Cart");

            migrationBuilder.RenameTable(
                name: "Cart",
                newName: "Carts");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Providers",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Providers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Parts",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Parts",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "color",
                table: "Parts",
                newName: "Color");

            migrationBuilder.RenameColumn(
                name: "category",
                table: "Parts",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "article",
                table: "Parts",
                newName: "Article");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Parts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "PartProviders",
                newName: "TotalParts");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "PartProviders",
                newName: "PartCost");

            migrationBuilder.RenameColumn(
                name: "provider_id",
                table: "PartProviders",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "part_id",
                table: "PartProviders",
                newName: "PartId");

            migrationBuilder.RenameIndex(
                name: "IX_PartProviders_provider_id",
                table: "PartProviders",
                newName: "IX_PartProviders_ProviderId");

            migrationBuilder.RenameColumn(
                name: "status",
                table: "Orders",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Orders",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "creation_time",
                table: "Orders",
                newName: "OrderCreationTime");

            migrationBuilder.RenameColumn(
                name: "finish_time",
                table: "Orders",
                newName: "FinishDate");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "OrderParts",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "provider_id",
                table: "OrderParts",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "OrderParts",
                newName: "AmountPart");

            migrationBuilder.RenameColumn(
                name: "order_id",
                table: "OrderParts",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "part_id",
                table: "OrderParts",
                newName: "PartId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderParts_order_id",
                table: "OrderParts",
                newName: "IX_OrderParts_OrderId");

            migrationBuilder.RenameColumn(
                name: "model",
                table: "Cars",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "mark",
                table: "Cars",
                newName: "Mark");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Cars",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "fuel_type",
                table: "Cars",
                newName: "FuelType");

            migrationBuilder.RenameColumn(
                name: "creation_year",
                table: "Cars",
                newName: "CreationYear");

            migrationBuilder.RenameColumn(
                name: "car_id",
                table: "CarParts",
                newName: "CarId");

            migrationBuilder.RenameColumn(
                name: "part_id",
                table: "CarParts",
                newName: "PartId");

            migrationBuilder.RenameIndex(
                name: "IX_CarParts_car_id",
                table: "CarParts",
                newName: "IX_CarParts_CarId");

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "Cards",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "attempts",
                table: "Cards",
                newName: "Attempts");

            migrationBuilder.RenameColumn(
                name: "pin",
                table: "Cards",
                newName: "PinCode");

            migrationBuilder.RenameColumn(
                name: "finish_date",
                table: "Cards",
                newName: "FinishDate");

            migrationBuilder.RenameColumn(
                name: "creation_date",
                table: "Cards",
                newName: "CreationDate");

            migrationBuilder.RenameColumn(
                name: "number",
                table: "Cards",
                newName: "CardNumber");

            migrationBuilder.RenameColumn(
                name: "street",
                table: "Address",
                newName: "Street");

            migrationBuilder.RenameColumn(
                name: "city",
                table: "Address",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Address",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "house_number",
                table: "Address",
                newName: "House");

            migrationBuilder.RenameColumn(
                name: "apartament_number",
                table: "Address",
                newName: "Apartament");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "Accounts",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Accounts",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "balance",
                table: "Accounts",
                newName: "Balance");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Accounts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "Accounts",
                newName: "UserRole");

            migrationBuilder.RenameColumn(
                name: "pass",
                table: "Accounts",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "creation_date",
                table: "Accounts",
                newName: "CreationTime");

            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Carts",
                newName: "Amount");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Carts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "provider_id",
                table: "Carts",
                newName: "ProviderId");

            migrationBuilder.RenameColumn(
                name: "part_id",
                table: "Carts",
                newName: "PartId");

            migrationBuilder.RenameColumn(
                name: "car_id",
                table: "Carts",
                newName: "CarId");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "Carts",
                newName: "AccountId");

            migrationBuilder.RenameIndex(
                name: "IX_Cart_account_id",
                table: "Carts",
                newName: "IX_Carts_AccountId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FinishDate",
                table: "Cards",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                table: "Carts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Address_Orders_Id",
                table: "Address",
                column: "Id",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarParts_Cars_CarId",
                table: "CarParts",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarParts_Parts_PartId",
                table: "CarParts",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Accounts_AccountId",
                table: "Carts",
                column: "AccountId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderParts_Orders_OrderId",
                table: "OrderParts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderParts_Parts_PartId",
                table: "OrderParts",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartProviders_Parts_PartId",
                table: "PartProviders",
                column: "PartId",
                principalTable: "Parts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartProviders_Providers_ProviderId",
                table: "PartProviders",
                column: "ProviderId",
                principalTable: "Providers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
