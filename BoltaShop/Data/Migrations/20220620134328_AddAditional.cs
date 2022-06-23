using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoltaShop.Data.Migrations
{
    public partial class AddAditional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Duljina",
                table: "Books",
                newName: "Debljina");

            migrationBuilder.AddColumn<int>(
                name: "BookBinding",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OpisKratki",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Snizenje",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BookBinding",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "OpisKratki",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Snizenje",
                table: "Books");

            migrationBuilder.RenameColumn(
                name: "Debljina",
                table: "Books",
                newName: "Duljina");
        }
    }
}
