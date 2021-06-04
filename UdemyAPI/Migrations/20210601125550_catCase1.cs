using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class catCase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Course_ShoppingCard_ShoppingCardCardId",
            //    table: "Course");

            //migrationBuilder.DropIndex(
            //    name: "IX_Course_ShoppingCardCardId",
            //    table: "Course");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_ShoppingCard",
            //    table: "ShoppingCard");

            //migrationBuilder.DropColumn(
            //    name: "CardId",
            //    table: "Course");

            //migrationBuilder.DropColumn(
            //    name: "ShoppingCardCardId",
            //    table: "Course");

            //migrationBuilder.RenameTable(
            //    name: "ShoppingCard",
            //    newName: "ShoppingCards");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_ShoppingCards",
            //    table: "ShoppingCards",
            //    column: "CardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingCards",
                table: "ShoppingCards");

            migrationBuilder.RenameTable(
                name: "ShoppingCards",
                newName: "ShoppingCard");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingCardCardId",
                table: "Course",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingCard",
                table: "ShoppingCard",
                column: "CardId");

            migrationBuilder.CreateIndex(
                name: "IX_Course_ShoppingCardCardId",
                table: "Course",
                column: "ShoppingCardCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_ShoppingCard_ShoppingCardCardId",
                table: "Course",
                column: "ShoppingCardCardId",
                principalTable: "ShoppingCard",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
