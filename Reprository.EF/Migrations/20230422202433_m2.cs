﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Reprository.EF.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_Orders_OrderId",
                table: "shoppingCarts");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "shoppingCarts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_Orders_OrderId",
                table: "shoppingCarts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_shoppingCarts_Orders_OrderId",
                table: "shoppingCarts");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "shoppingCarts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_shoppingCarts_Orders_OrderId",
                table: "shoppingCarts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
