using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reprository.EF.Migrations
{
    /// <inheritdoc />
    public partial class m14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_MainProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Products_MainProductId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Stores_StoreId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Profits_Products_MainProductId",
                table: "Profits");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Images_ImageId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_ImageId",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Payments_StoreId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Payments");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Stores",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainProductId",
                table: "Profits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainProductId",
                table: "Discounts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainProductId",
                table: "CartItems",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_MainProductId",
                table: "CartItems",
                column: "MainProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Products_MainProductId",
                table: "Discounts",
                column: "MainProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Profits_Products_MainProductId",
                table: "Profits",
                column: "MainProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Products_MainProductId",
                table: "CartItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Products_MainProductId",
                table: "Discounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Profits_Products_MainProductId",
                table: "Profits");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Stores");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Stores",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainProductId",
                table: "Profits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Payments",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MainProductId",
                table: "Discounts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MainProductId",
                table: "CartItems",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_ImageId",
                table: "Stores",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_StoreId",
                table: "Payments",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Products_MainProductId",
                table: "CartItems",
                column: "MainProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Products_MainProductId",
                table: "Discounts",
                column: "MainProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Stores_StoreId",
                table: "Payments",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Profits_Products_MainProductId",
                table: "Profits",
                column: "MainProductId",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Images_ImageId",
                table: "Stores",
                column: "ImageId",
                principalTable: "Images",
                principalColumn: "Id");
        }
    }
}
