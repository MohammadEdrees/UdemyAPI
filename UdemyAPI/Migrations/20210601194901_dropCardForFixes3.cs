using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class dropCardForFixes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Course_ShoppingCard_ShoppingCardCardId",
            //    table: "Course");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ShoppingCard_Instructor_InstId",
            //    table: "ShoppingCard");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ShoppingCard_Student_StdId",
            //    table: "ShoppingCard");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_ShoppingCard",
            //    table: "ShoppingCard");
         


            //migrationBuilder.RenameTable(
            //    name: "ShoppingCard",
            //    newName: "ShoppingCards");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ShoppingCard_StdId",
            //    table: "ShoppingCards",
            //    newName: "IX_ShoppingCards_StdId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ShoppingCard_InstId",
            //    table: "ShoppingCards",
            //    newName: "IX_ShoppingCards_InstId");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_ShoppingCards",
            //    table: "ShoppingCards",
            //    column: "CardId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Course_ShoppingCards_ShoppingCardCardId",
            //    table: "Course",
            //    column: "ShoppingCardCardId",
            //    principalTable: "ShoppingCards",
            //    principalColumn: "CardId",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ShoppingCards_Instructor_InstId",
            //    table: "ShoppingCards",
            //    column: "InstId",
            //    principalTable: "Instructor",
            //    principalColumn: "Inst_Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ShoppingCards_Student_StdId",
            //    table: "ShoppingCards",
            //    column: "StdId",
            //    principalTable: "Student",
            //    principalColumn: "Std_Id",
            //    onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Course_ShoppingCards_ShoppingCardCardId",
            //    table: "Course");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ShoppingCards_Instructor_InstId",
            //    table: "ShoppingCards");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ShoppingCards_Student_StdId",
            //    table: "ShoppingCards");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_ShoppingCards",
            //    table: "ShoppingCards");

            //migrationBuilder.RenameTable(
            //    name: "ShoppingCards",
            //    newName: "ShoppingCard");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ShoppingCards_StdId",
            //    table: "ShoppingCard",
            //    newName: "IX_ShoppingCard_StdId");

            //migrationBuilder.RenameIndex(
            //    name: "IX_ShoppingCards_InstId",
            //    table: "ShoppingCard",
            //    newName: "IX_ShoppingCard_InstId");

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_ShoppingCard",
            //    table: "ShoppingCard",
            //    column: "CardId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Course_ShoppingCard_ShoppingCardCardId",
            //    table: "Course",
            //    column: "ShoppingCardCardId",
            //    principalTable: "ShoppingCard",
            //    principalColumn: "CardId",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ShoppingCard_Instructor_InstId",
            //    table: "ShoppingCard",
            //    column: "InstId",
            //    principalTable: "Instructor",
            //    principalColumn: "Inst_Id",
            //    onDelete: ReferentialAction.Restrict);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ShoppingCard_Student_StdId",
            //    table: "ShoppingCard",
            //    column: "StdId",
            //    principalTable: "Student",
            //    principalColumn: "Std_Id",
            //    onDelete: ReferentialAction.Restrict);
        }
    }
}
