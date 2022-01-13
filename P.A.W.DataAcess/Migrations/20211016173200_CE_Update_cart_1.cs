using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAWDataAcess.Migrations
{
    public partial class CE_Update_cart_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CartId",
                table: "Songs",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "total",
                table: "Carts",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Songs_CartId",
                table: "Songs",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Carts_CartId",
                table: "Songs",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Carts_CartId",
                table: "Songs");

            migrationBuilder.DropIndex(
                name: "IX_Songs_CartId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "total",
                table: "Carts");
        }
    }
}
