using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SquashNext.Data.Migrations
{
    public partial class MakeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Theme",
                table: "Issues",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Milestone",
                table: "Issues",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Theme",
                table: "Issues",
                nullable: false);

            migrationBuilder.AlterColumn<int>(
                name: "Milestone",
                table: "Issues",
                nullable: false);
        }
    }
}
