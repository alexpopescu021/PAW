using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAWDataAcess.Migrations
{
    public partial class History : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HistoryId",
                table: "Songs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Histories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Histories", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Songs_HistoryId",
                table: "Songs",
                column: "HistoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Songs_Histories_HistoryId",
                table: "Songs",
                column: "HistoryId",
                principalTable: "Histories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Songs_Histories_HistoryId",
                table: "Songs");

            migrationBuilder.DropTable(
                name: "Histories");

            migrationBuilder.DropIndex(
                name: "IX_Songs_HistoryId",
                table: "Songs");

            migrationBuilder.DropColumn(
                name: "HistoryId",
                table: "Songs");
        }
    }
}
