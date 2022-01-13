using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAWDataAcess.Migrations
{
    public partial class CE_Update_Wishlist : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "WishlistId",
                table: "Songs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Wishlist",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wishlist", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_WishlistId",
                table: "Songs",
                column: "WishlistId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Wishlist_WishlistId",
                table: "Songs",
                column: "WishlistId",
                principalTable: "Wishlist",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Wishlist_WishlistId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "Wishlist");

            migrationBuilder.DropIndex(
                name: "IX_Songs_WishlistId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "WishlistId",
                table: "Songs");
        }
    }
}
