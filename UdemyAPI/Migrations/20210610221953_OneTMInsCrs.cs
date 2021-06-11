using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class OneTMInsCrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_InstId",
                table: "Course",
                column: "InstId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Instructor_InstId",
                table: "Course",
                column: "InstId",
                principalTable: "Instructor",
                principalColumn: "Inst_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Instructor_InstId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_InstId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "InstId",
                table: "Course");
        }
    }
}
