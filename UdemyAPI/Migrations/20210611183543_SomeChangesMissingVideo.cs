using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class SomeChangesMissingVideo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_CourseSections_SectionId",
                table: "Video");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Video",
                table: "Video");

            migrationBuilder.RenameTable(
                name: "Video",
                newName: "Lecture");

            migrationBuilder.RenameIndex(
                name: "IX_Video_SectionId",
                table: "Lecture",
                newName: "IX_Lecture_SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Lecture",
                table: "Lecture",
                column: "Lecture_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Lecture_CourseSections_SectionId",
                table: "Lecture",
                column: "SectionId",
                principalTable: "CourseSections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Cascade,
                onUpdate: ReferentialAction.Cascade
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Lecture_CourseSections_SectionId",
                table: "Lecture");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Lecture",
                table: "Lecture");

            migrationBuilder.RenameTable(
                name: "Lecture",
                newName: "Video");

            migrationBuilder.RenameIndex(
                name: "IX_Lecture_SectionId",
                table: "Video",
                newName: "IX_Video_SectionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Video",
                table: "Video",
                column: "Lecture_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_CourseSections_SectionId",
                table: "Video",
                column: "SectionId",
                principalTable: "CourseSections",
                principalColumn: "SectionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
