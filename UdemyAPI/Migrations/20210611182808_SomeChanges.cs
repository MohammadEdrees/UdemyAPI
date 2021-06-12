using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class SomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Card_CId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "LectureLink",
                table: "CourseSections");

            migrationBuilder.DropColumn(
                name: "LectureTitle",
                table: "CourseSections");

            migrationBuilder.RenameColumn(
                name: "Vid_Id",
                table: "Video",
                newName: "Lecture_Id");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Video",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Video",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CId",
                table: "Course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Card_CId",
                table: "Course",
                column: "CId",
                principalTable: "Card",
                principalColumn: "CId",
                onDelete: ReferentialAction.Cascade,
                onUpdate: ReferentialAction.Cascade
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Card_CId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "Link",
                table: "Video");

            migrationBuilder.RenameColumn(
                name: "Lecture_Id",
                table: "Video",
                newName: "Vid_Id");

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Video",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LectureLink",
                table: "CourseSections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LectureTitle",
                table: "CourseSections",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Card_CId",
                table: "Course",
                column: "CId",
                principalTable: "Card",
                principalColumn: "CId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
