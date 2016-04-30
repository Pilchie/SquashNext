using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SquashNext.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Issues",
                columns: table => new
                {
                    GitHubIssueNumber = table.Column<int>(nullable: false)
                        .Annotation("Autoincrement", true),
                    HtmlUrl = table.Column<string>(nullable: true),
                    Milestone = table.Column<int>(nullable: false),
                    Priority = table.Column<int>(nullable: true),
                    StoryPoints = table.Column<int>(nullable: true),
                    Theme = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issues", x => x.GitHubIssueNumber);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Issues");
        }
    }
}
