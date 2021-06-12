using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class cardCases2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CId",
                table: "Instructor",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "InstId",
                table: "Card",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StdId",
                table: "Card",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Card_InstId",
                table: "Card",
                column: "InstId",
                unique: true,
                filter: "[InstId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Card_StdId",
                table: "Card",
                column: "StdId",
                unique: true,
                filter: "[StdId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Instructor_InstId",
                table: "Card",
                column: "InstId",
                principalTable: "Instructor",
                principalColumn: "Inst_Id",
                onDelete: ReferentialAction.Restrict
               
                );

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Student_StdId",
                table: "Card",
                column: "StdId",
                principalTable: "Student",
                principalColumn: "Std_Id",
                onDelete: ReferentialAction.Restrict
              
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Instructor_InstId",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_Card_Student_StdId",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Card_InstId",
                table: "Card");

            migrationBuilder.DropIndex(
                name: "IX_Card_StdId",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "CId",
                table: "Instructor");

            migrationBuilder.DropColumn(
                name: "InstId",
                table: "Card");

            migrationBuilder.DropColumn(
                name: "StdId",
                table: "Card");
        }
    }
}
