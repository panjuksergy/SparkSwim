using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SparkSwim.GoodsService.Migrations
{
    /// <inheritdoc />
    public partial class microUpdateForDiscount11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscountId",
                table: "Products");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DiscountId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
