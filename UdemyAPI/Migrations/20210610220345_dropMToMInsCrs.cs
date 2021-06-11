using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class dropMToMInsCrs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inst_Crs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inst_Crs",
                columns: table => new
                {
                    Inst_Id = table.Column<int>(type: "int", nullable: false),
                    Crs_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inst_Crs", x => new { x.Inst_Id, x.Crs_Id });
                    table.ForeignKey(
                        name: "FK_Inst_Crs_Course_Crs_Id",
                        column: x => x.Crs_Id,
                        principalTable: "Course",
                        principalColumn: "Crs_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inst_Crs_Instructor_Inst_Id",
                        column: x => x.Inst_Id,
                        principalTable: "Instructor",
                        principalColumn: "Inst_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inst_Crs_Crs_Id",
                table: "Inst_Crs",
                column: "Crs_Id");
        }
    }
}
