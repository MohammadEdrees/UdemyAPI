using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class fixCatSupCatrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupCategs_Category_CategoryId",
                table: "SupCategs");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_SupCategs_supCategSupCatId",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupCategs",
                table: "SupCategs");

            migrationBuilder.RenameTable(
                name: "SupCategs",
                newName: "SupCateg");

            migrationBuilder.RenameIndex(
                name: "IX_SupCategs_CategoryId",
                table: "SupCateg",
                newName: "IX_SupCateg_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupCateg",
                table: "SupCateg",
                column: "SupCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupCateg_Category_CategoryId",
                table: "SupCateg",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_SupCateg_supCategSupCatId",
                table: "Topic",
                column: "supCategSupCatId",
                principalTable: "SupCateg",
                principalColumn: "SupCatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SupCateg_Category_CategoryId",
                table: "SupCateg");

            migrationBuilder.DropForeignKey(
                name: "FK_Topic_SupCateg_supCategSupCatId",
                table: "Topic");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SupCateg",
                table: "SupCateg");

            migrationBuilder.RenameTable(
                name: "SupCateg",
                newName: "SupCategs");

            migrationBuilder.RenameIndex(
                name: "IX_SupCateg_CategoryId",
                table: "SupCategs",
                newName: "IX_SupCategs_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SupCategs",
                table: "SupCategs",
                column: "SupCatId");

            migrationBuilder.AddForeignKey(
                name: "FK_SupCategs_Category_CategoryId",
                table: "SupCategs",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_SupCategs_supCategSupCatId",
                table: "Topic",
                column: "supCategSupCatId",
                principalTable: "SupCategs",
                principalColumn: "SupCatId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
