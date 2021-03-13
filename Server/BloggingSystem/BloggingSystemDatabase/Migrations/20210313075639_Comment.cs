using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BloggingSystemDatabase.Migrations
{
    public partial class Comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comment");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "Comment",
                newName: "UserName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Comment",
                newName: "UpdatedBy");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Comment",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Comment",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Comment",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
