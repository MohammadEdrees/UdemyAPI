using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class notNullTopic2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.AddForeignKey(
                name: "FK_Course_Topic_TopId",
                table: "Course",
                column: "TopId",
                principalTable: "Topic",
                principalColumn: "Top_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
