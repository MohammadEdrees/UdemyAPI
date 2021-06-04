using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class cart1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StdId",
                table: "ShoppingCards",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCards_StdId",
                table: "ShoppingCards",
                column: "StdId",
                unique: true,
                filter: "[StdId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ShoppingCards_Student_StdId",
                table: "ShoppingCards",
                column: "StdId",
                principalTable: "Student",
                principalColumn: "Std_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShoppingCards_Student_StdId",
                table: "ShoppingCards");

            migrationBuilder.DropIndex(
                name: "IX_ShoppingCards_StdId",
                table: "ShoppingCards");

            migrationBuilder.DropColumn(
                name: "StdId",
                table: "ShoppingCards");
        }
    }
}
