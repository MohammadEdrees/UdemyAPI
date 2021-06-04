using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class Cardz3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstId",
                table: "ShoppingCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCards_InstId",
                table: "ShoppingCards",
                column: "InstId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCards_Instructor_InstId",
                table: "ShoppingCards",
                column: "InstId",
                principalTable: "Instructor",
                principalColumn: "Inst_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCards_Instructor_InstId",
                table: "ShoppingCards");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCards_InstId",
                table: "ShoppingCards");

            migrationBuilder.DropColumn(
                name: "InstId",
                table: "ShoppingCards");
        }
    }
}
