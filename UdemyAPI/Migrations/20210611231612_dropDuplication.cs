using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class dropDuplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_ShoppingCards_CardId",
                table: "Course");

            migrationBuilder.DropTable(
                name: "ShoppingCards");

            migrationBuilder.DropIndex(
                name: "IX_Course_CardId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Course");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShoppingCards",
                columns: table => new
                {
                    CardId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InstId = table.Column<int>(type: "int", nullable: true),
                    StdId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCards", x => x.CardId);
                    table.ForeignKey(
                        name: "FK_ShoppingCards_Instructor_InstId",
                        column: x => x.InstId,
                        principalTable: "Instructor",
                        principalColumn: "Inst_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShoppingCards_Student_StdId",
                        column: x => x.StdId,
                        principalTable: "Student",
                        principalColumn: "Std_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_CardId",
                table: "Course",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCards_InstId",
                table: "ShoppingCards",
                column: "InstId",
                unique: true,
                filter: "[InstId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCards_StdId",
                table: "ShoppingCards",
                column: "StdId",
                unique: true,
                filter: "[StdId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_ShoppingCards_CardId",
                table: "Course",
                column: "CardId",
                principalTable: "ShoppingCards",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
