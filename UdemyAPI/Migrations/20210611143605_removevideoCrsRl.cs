using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class removevideoCrsRl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Video_Course_Crs_Id",
                table: "Video");

            migrationBuilder.DropIndex(
                name: "IX_Video_Crs_Id",
                table: "Video");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Video_Crs_Id",
                table: "Video",
                column: "Crs_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Video_Course_Crs_Id",
                table: "Video",
                column: "Crs_Id",
                principalTable: "Course",
                principalColumn: "Crs_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
