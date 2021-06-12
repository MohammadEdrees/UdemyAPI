using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class VideoSectionsRel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Crs_Id",
                table: "Video",
                newName: "SectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Video_SectionId",
                table: "Video",
                column: "SectionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_CourseSections_SectionId",
                table: "Video",
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
                name: "FK_Video_CourseSections_SectionId",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_SectionId",
                table: "Video");

            migrationBuilder.RenameColumn(
                name: "SectionId",
                table: "Video",
                newName: "Crs_Id");
        }
    }
}
