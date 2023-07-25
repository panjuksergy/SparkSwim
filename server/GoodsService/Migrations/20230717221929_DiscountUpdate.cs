using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SparkSwim.GoodsService.Migrations
{
    /// <inheritdoc />
    public partial class DiscountUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Discount_Products_ProductId",
                table: "Discount");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Discount",
                newName: "DiscountId");

            migrationBuilder.AddColumn<Guid>(
                name: "DiscountId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Discount_ProductId",
                table: "Products",
                column: "ProductId",
                principalTable: "Discount",
                principalColumn: "DiscountId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Discount_ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "DiscountId",
                table: "Discount",
                newName: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Discount_Products_ProductId",
                table: "Discount",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
