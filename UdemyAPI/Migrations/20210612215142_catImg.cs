using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class catImg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imgPath",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imgPath",
                table: "Category");
        }
    }
}
