using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PAWDataAcess.Migrations
{
    public partial class Quiz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Quizzes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Question = table.Column<string>(nullable: true),
                    Answer1 = table.Column<string>(nullable: true),
                    Answer2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quizzes", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Quizzes");
        }
    }
}
