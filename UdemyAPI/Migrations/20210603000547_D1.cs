using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class D1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Course_Topic",
            //    table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_Top_Id",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Top_Id",
                table: "Course");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Top_Id",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Course_Top_Id",
                table: "Course",
                column: "Top_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Topic",
                table: "Course",
                column: "Top_Id",
                principalTable: "Topic",
                principalColumn: "Top_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
