using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class addSupCatRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SupCatId",
                table: "Topic",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "supCategSupCatId",
                table: "Topic",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topic_supCategSupCatId",
                table: "Topic",
                column: "supCategSupCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_SupCategs_supCategSupCatId",
                table: "Topic",
                column: "supCategSupCatId",
                principalTable: "SupCategs",
                principalColumn: "SupCatId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_SupCategs_supCategSupCatId",
                table: "Topic");

            migrationBuilder.DropIndex(
                name: "IX_Topic_supCategSupCatId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "SupCatId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "supCategSupCatId",
                table: "Topic");
        }
    }
}
