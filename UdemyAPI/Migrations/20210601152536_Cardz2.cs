using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class Cardz2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StdId",
                table: "ShoppingCards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingCards_StdId",
                table: "ShoppingCards",
                column: "StdId",
                unique: true);

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
