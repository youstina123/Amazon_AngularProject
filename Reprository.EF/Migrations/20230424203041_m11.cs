using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reprository.EF.Migrations
{
    /// <inheritdoc />
    public partial class m11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalProfit",
                table: "Admins",
                type: "float",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalProfit",
                table: "Admins");
        }
    }
}
