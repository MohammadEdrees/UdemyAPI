using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class cart4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstId",
                table: "ShoppingCards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCards_InstId",
                table: "ShoppingCards",
                column: "InstId",
                unique: true,
                filter: "[InstId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCards_Instructor_InstId",
                table: "ShoppingCards",
                column: "InstId",
                principalTable: "Instructor",
                principalColumn: "Inst_Id",
                onDelete: ReferentialAction.Cascade,
                onUpdate:ReferentialAction.Cascade);
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
