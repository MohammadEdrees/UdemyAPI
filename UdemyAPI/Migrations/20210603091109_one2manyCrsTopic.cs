using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class one2manyCrsTopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TopId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_TopId",
                table: "Course",
                column: "TopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Topic_TopId",
                table: "Course",
                column: "TopId",
                principalTable: "Topic",
                principalColumn: "Top_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Topic_TopId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_TopId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "TopId",
                table: "Course");
        }
    }
}
