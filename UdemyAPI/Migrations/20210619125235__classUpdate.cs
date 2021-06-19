using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class _classUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Student",
                newName: "_Class");

            migrationBuilder.RenameColumn(
                name: "Class",
                table: "Instructor",
                newName: "_Class");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "_Class",
                table: "Student",
                newName: "Class");

            migrationBuilder.RenameColumn(
                name: "_Class",
                table: "Instructor",
                newName: "Class");
        }
    }
}
