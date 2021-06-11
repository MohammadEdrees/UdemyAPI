using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class OneTMInsCrs2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Instructor_InstId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "InstId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Instructor_InstId",
                table: "Course",
                column: "InstId",
                principalTable: "Instructor",
                principalColumn: "Inst_Id",
                onDelete: ReferentialAction.Cascade,
                onUpdate: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Instructor_InstId",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "InstId",
                table: "Course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Instructor_InstId",
                table: "Course",
                column: "InstId",
                principalTable: "Instructor",
                principalColumn: "Inst_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
