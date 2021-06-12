using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class MMRelationCardCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseInCards",
                columns: table => new
                {
                    CrsId = table.Column<int>(type: "int", nullable: false),
                    CId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseInCards", x => new { x.CId, x.CrsId });
                    table.ForeignKey(
                        name: "FK_CourseInCards_Card_CId",
                        column: x => x.CId,
                        principalTable: "Card",
                        principalColumn: "CId",
                        onDelete: ReferentialAction.NoAction,
                        onUpdate: ReferentialAction.NoAction

                        );
                    table.ForeignKey(
                        name: "FK_CourseInCards_Course_CrsId",
                        column: x => x.CrsId,
                        principalTable: "Course",
                        principalColumn: "Crs_Id",
                        onDelete: ReferentialAction.Cascade,
                         onUpdate: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseInCards_CrsId",
                table: "CourseInCards",
                column: "CrsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseInCards");
        }
    }
}
