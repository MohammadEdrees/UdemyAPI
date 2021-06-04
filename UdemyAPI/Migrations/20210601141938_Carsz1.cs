using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class Carsz1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AddColumn<int>(
            //    name: "CardId",
            //    table: "Course",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCardCardId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_ShoppingCardCardId",
                table: "Course",
                column: "ShoppingCardCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_ShoppingCards_ShoppingCardCardId",
                table: "Course",
                column: "ShoppingCardCardId",
                principalTable: "ShoppingCards",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_ShoppingCards_ShoppingCardCardId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_ShoppingCardCardId",
                table: "Course");

            //migrationBuilder.DropColumn(
            //    name: "CardId",
            //    table: "Course");

            migrationBuilder.DropColumn(
                name: "ShoppingCardCardId",
                table: "Course");
        }
    }
}
