using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Categ_Id",
                table: "Topic");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SupCategs",
                newName: "SupCatTitle");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "SupCategs",
                newName: "SupCatId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SupCatTitle",
                table: "SupCategs",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "SupCatId",
                table: "SupCategs",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "Categ_Id",
                table: "Topic",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
