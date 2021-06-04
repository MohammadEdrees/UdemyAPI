using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class test10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_ShoppingCards_ShoppingCardCardId",
                table: "Course");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_Course_Topic_Top_Id",
            //    table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_ShoppingCardCardId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ShoppingCardCardId",
                table: "Course");

            //migrationBuilder.AddColumn<int>(
            //    name: "CardId",
            //    table: "Course",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Course_CardId",
            //    table: "Course",
            //    column: "CardId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Course_ShoppingCards_CardId",
            //    table: "Course",
            //    column: "CardId",
            //    principalTable: "ShoppingCards",
            //    principalColumn: "CardId",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Course_Topic",
            //    table: "Course",
            //    column: "TopId",
            //    principalTable: "Topic",
            //    principalColumn: "Top_Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Course_ShoppingCards_CardId",
            //    table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Topic",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_CardId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Course");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Topic_Top_Id",
                table: "Course",
                column: "Top_Id",
                principalTable: "Topic",
                principalColumn: "Top_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
