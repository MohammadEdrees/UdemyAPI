using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class studentCourseStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Std_Crs",
                columns: table => new
                {
                    Std_Id = table.Column<int>(type: "int", nullable: false),
                    Crs_Id = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true),
                    Certificate = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Std_Crs", x => new { x.Std_Id, x.Crs_Id });
                    table.ForeignKey(
                        name: "FK_Std_Crs_Course_Crs_Id",
                        column: x => x.Crs_Id,
                        principalTable: "Course",
                        principalColumn: "Crs_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Std_Crs_Student_Std_Id",
                        column: x => x.Std_Id,
                        principalTable: "Student",
                        principalColumn: "std_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Std_Crs_Crs_Id",
                table: "Std_Crs",
                column: "Crs_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Std_Crs");
        }
    }
}
