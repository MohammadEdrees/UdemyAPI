using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class one2mRCardVsCrsz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Course_CardId",
                table: "Course",
                column: "CardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_ShoppingCards_CardId",
                table: "Course",
                column: "CardId",
                principalTable: "ShoppingCards",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_ShoppingCards_CardId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_CardId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Course");
        }
    }
}
