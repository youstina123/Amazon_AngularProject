using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reprository.EF.Migrations
{
    /// <inheritdoc />
    public partial class m15 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Stores_StoreId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_StoreId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "StoreId",
                table: "Categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StoreId",
                table: "Categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_StoreId",
                table: "Categories",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Stores_StoreId",
                table: "Categories",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id");
        }
    }
}
