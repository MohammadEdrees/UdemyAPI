using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class removeCourseCardRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_ShoppingCards_CardId",
                table: "Course");

            //migrationBuilder.RenameColumn(
            //    name: "CardId",
            //    table: "Course",
            //    newName: "ShoppingCardCardId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Course_CardId",
            //    table: "Course",
            //    newName: "IX_Course_ShoppingCardCardId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Course_ShoppingCards_ShoppingCardCardId",
            //    table: "Course",
            //    column: "ShoppingCardCardId",
            //    principalTable: "ShoppingCards",
            //    principalColumn: "CardId",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Course_ShoppingCards_ShoppingCardCardId",
            //    table: "Course");

            //migrationBuilder.RenameColumn(
            //    name: "ShoppingCardCardId",
            //    table: "Course",
            //    newName: "CardId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Course_ShoppingCardCardId",
            //    table: "Course",
            //    newName: "IX_Course_CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_ShoppingCards_CardId",
                table: "Course",
                column: "CardId",
                principalTable: "ShoppingCards",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
