using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reprository.EF.Migrations
{
    /// <inheritdoc />
    public partial class m10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discounts_Admins_AdminId",
                table: "Discounts");

            migrationBuilder.DropIndex(
                name: "IX_Discounts_AdminId",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Discounts");

            migrationBuilder.AddColumn<int>(
                name: "DiscountId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                column: "DiscountId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "DiscountId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Products_DiscountId",
                table: "Products",
                column: "DiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products",
                column: "DiscountId",
                principalTable: "Discounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discounts_DiscountId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_DiscountId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "Discounts",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Discounts_AdminId",
                table: "Discounts",
                column: "AdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discounts_Admins_AdminId",
                table: "Discounts",
                column: "AdminId",
                principalTable: "Admins",
                principalColumn: "ApplicationUserId");
        }
    }
}
