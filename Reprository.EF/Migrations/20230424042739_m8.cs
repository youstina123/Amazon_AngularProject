using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reprository.EF.Migrations
{
    /// <inheritdoc />
    public partial class m8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profits_Products_MainProductId",
                table: "Profits");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Profits",
                newName: "VendorProfitValue");

            migrationBuilder.AlterColumn<int>(
                name: "MainProductId",
                table: "Profits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "AdminProfitValue",
                table: "Profits",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Profits_Products_MainProductId",
                table: "Profits",
                column: "MainProductId",
                principalTable: "Products",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Profits_Products_MainProductId",
                table: "Profits");

            migrationBuilder.DropColumn(
                name: "AdminProfitValue",
                table: "Profits");

            migrationBuilder.RenameColumn(
                name: "VendorProfitValue",
                table: "Profits",
                newName: "Value");

            migrationBuilder.AlterColumn<int>(
                name: "MainProductId",
                table: "Profits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Profits_Products_MainProductId",
                table: "Profits",
                column: "MainProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
