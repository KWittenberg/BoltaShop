using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoltaShop.Data.Migrations
{
    public partial class somefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Valid",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "RedovnaCijena",
                table: "Books",
                newName: "CijenaSnizenje");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Books",
                newName: "StartDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "Books",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Books",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "CijenaSnizenje",
                table: "Books",
                newName: "RedovnaCijena");

            migrationBuilder.AddColumn<bool>(
                name: "Valid",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
