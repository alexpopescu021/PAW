using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAWDataAcess.Migrations
{
    public partial class quiz_change : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Question",
                table: "Quizzes");

            migrationBuilder.AddColumn<Guid>(
                name: "SongId",
                table: "Quizzes",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SongId",
                table: "Quizzes");

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "Quizzes",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
