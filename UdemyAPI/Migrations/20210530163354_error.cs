using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class error : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Topic_SupCategs_supCategSupCatId",
            //    table: "Topic");

            //migrationBuilder.DropIndex(
            //    name: "IX_Topic_supCategSupCatId",
            //    table: "Topic");

            //migrationBuilder.DropColumn(
            //    name: "supCategSupCatId",
            //    table: "Topic");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Topic_SupCatId",
            //    table: "Topic",
            //    column: "SupCatId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Topic_SupCategs",
            //    table: "Topic",
            //    column: "SupCatId",
            //    principalTable: "SupCategs",
            //    principalColumn: "SupCatId",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Topic_SupCategs",
            //    table: "Topic");

            //migrationBuilder.DropIndex(
            //    name: "IX_Topic_SupCatId",
            //    table: "Topic");

            //migrationBuilder.AddColumn<int>(
            //    name: "supCategSupCatId",
            //    table: "Topic",
            //    type: "int",
            //    nullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Topic_supCategSupCatId",
            //    table: "Topic",
            //    column: "supCategSupCatId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Topic_SupCategs_supCategSupCatId",
            //    table: "Topic",
            //    column: "supCategSupCatId",
            //    principalTable: "SupCategs",
            //    principalColumn: "SupCatId",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
