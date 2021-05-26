using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class removeTopicRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Category",
                table: "Topic");

            //migrationBuilder.DropIndex(
            //    name: "IX_Topic_Categ_Id",
            //    table: "Topic");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Topic_Categ_Id",
                table: "Topic",
                column: "Categ_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Category",
                table: "Topic",
                column: "Categ_Id",
                principalTable: "Category",
                principalColumn: "Category_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
