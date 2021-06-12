using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class CourseSectionsRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrsId",
                table: "CourseSections",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CourseSections_CrsId",
                table: "CourseSections",
                column: "CrsId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSections_Course_CrsId",
                table: "CourseSections",
                column: "CrsId",
                principalTable: "Course",
                principalColumn: "Crs_Id",
                onDelete: ReferentialAction.Cascade,
                onUpdate: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSections_Course_CrsId",
                table: "CourseSections");

            migrationBuilder.DropIndex(
                name: "IX_CourseSections_CrsId",
                table: "CourseSections");

            migrationBuilder.DropColumn(
                name: "CrsId",
                table: "CourseSections");
        }
    }
}
