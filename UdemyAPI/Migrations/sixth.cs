using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class RefreshContext3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Course",
                newName: "Levels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Levels",
                table: "Course",
                newName: "Level");

        
        }
    }
}
