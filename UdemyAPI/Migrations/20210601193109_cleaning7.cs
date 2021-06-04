using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class cleaning7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        //    migrationBuilder.DropForeignKey(
        //        name: "FK_ShoppingCards_Instructor_InstId",
        //        table: "ShoppingCards");

        //    migrationBuilder.DropForeignKey(
        //        name: "FK_ShoppingCards_Student_StdId",
        //        table: "ShoppingCards");

        //    migrationBuilder.DropIndex(
        //        name: "IX_ShoppingCards_InstId",
        //        table: "ShoppingCards");

        //    migrationBuilder.DropIndex(
        //        name: "IX_ShoppingCards_StdId",
        //        table: "ShoppingCards");

        //    migrationBuilder.AlterColumn<int>(
        //        name: "StdId",
        //        table: "ShoppingCards",
        //        type: "int",
        //        nullable: true,
        //        oldClrType: typeof(int),
        //        oldType: "int");

        //    migrationBuilder.AlterColumn<int>(
        //        name: "InstId",
        //        table: "ShoppingCards",
        //        type: "int",
        //        nullable: true,
        //        oldClrType: typeof(int),
        //        oldType: "int");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ShoppingCards_InstId",
        //        table: "ShoppingCards",
        //        column: "InstId",
        //        unique: true,
        //        filter: "[InstId] IS NOT NULL");

        //    migrationBuilder.CreateIndex(
        //        name: "IX_ShoppingCards_StdId",
        //        table: "ShoppingCards",
        //        column: "StdId",
        //        unique: true,
        //        filter: "[StdId] IS NOT NULL");

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_ShoppingCards_Instructor_InstId",
        //        table: "ShoppingCards",
        //        column: "InstId",
        //        principalTable: "Instructor",
        //        principalColumn: "Inst_Id",
        //        onDelete: ReferentialAction.Restrict);

        //    migrationBuilder.AddForeignKey(
        //        name: "FK_ShoppingCards_Student_StdId",
        //        table: "ShoppingCards",
        //        column: "StdId",
        //        principalTable: "Student",
        //        principalColumn: "Std_Id",
        //        onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_ShoppingCards_Instructor_InstId",
            //    table: "ShoppingCards");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_ShoppingCards_Student_StdId",
            //    table: "ShoppingCards");

            //migrationBuilder.DropIndex(
            //    name: "IX_ShoppingCards_InstId",
            //    table: "ShoppingCards");

            //migrationBuilder.DropIndex(
            //    name: "IX_ShoppingCards_StdId",
            //    table: "ShoppingCards");

            //migrationBuilder.AlterColumn<int>(
            //    name: "StdId",
            //    table: "ShoppingCards",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.AlterColumn<int>(
            //    name: "InstId",
            //    table: "ShoppingCards",
            //    type: "int",
            //    nullable: false,
            //    defaultValue: 0,
            //    oldClrType: typeof(int),
            //    oldType: "int",
            //    oldNullable: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_ShoppingCards_InstId",
            //    table: "ShoppingCards",
            //    column: "InstId",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_ShoppingCards_StdId",
            //    table: "ShoppingCards",
            //    column: "StdId",
            //    unique: true);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ShoppingCards_Instructor_InstId",
            //    table: "ShoppingCards",
            //    column: "InstId",
            //    principalTable: "Instructor",
            //    principalColumn: "Inst_Id",
            //    onDelete: ReferentialAction.Cascade);

            //migrationBuilder.AddForeignKey(
            //    name: "FK_ShoppingCards_Student_StdId",
            //    table: "ShoppingCards",
            //    column: "StdId",
            //    principalTable: "Student",
            //    principalColumn: "Std_Id",
            //    onDelete: ReferentialAction.Cascade);
        }
    }
}
