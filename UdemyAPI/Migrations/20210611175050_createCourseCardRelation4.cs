using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class createCourseCardRelation4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CId",
                table: "Course",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Card",
                columns: table => new
                {
                    CId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Card", x => x.CId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CId",
                table: "Course",
                column: "CId");

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

            migrationBuilder.DropTable(
                name: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Course_CId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CId",
                table: "Course");
        }
    }
}
