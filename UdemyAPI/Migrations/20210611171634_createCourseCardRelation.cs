using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class createCourseCardRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      

            migrationBuilder.AddForeignKey(
                name: "FK_Course_ShoppingCards_CardId",
                table: "Course",
                column: "CardId",
                principalTable: "ShoppingCards",
                principalColumn: "CardId",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_ShoppingCards_CardId",
                table: "Course");

        }
    }
}
