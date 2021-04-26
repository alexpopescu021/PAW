using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAWDataAcess.Migrations
{
    public partial class quizagain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "SongId",
                table: "Quizzes",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_Quizzes_SongId",
                table: "Quizzes",
                column: "SongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Quizzes_Songs_SongId",
                table: "Quizzes",
                column: "SongId",
                principalTable: "Songs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Quizzes_Songs_SongId",
                table: "Quizzes");

            migrationBuilder.DropIndex(
                name: "IX_Quizzes_SongId",
                table: "Quizzes");

            migrationBuilder.AlterColumn<Guid>(
                name: "SongId",
                table: "Quizzes",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
