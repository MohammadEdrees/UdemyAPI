using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class cart7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Topic",
                table: "Course");

            //migrationBuilder.DropIndex(
            //    name: "IX_Course_Top_Id",
            //    table: "Course");

            migrationBuilder.DropColumn(
                name: "Top_Id",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "Crs_Id",
                table: "Course",
                newName: "CrsId");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldDefaultValueSql: "(N'')");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Course",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

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

            migrationBuilder.DropColumn(
                name: "ShoppingCardCardId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "CrsId",
                table: "Course",
                newName: "Crs_Id");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Course",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValueSql: "(N'')",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "Course",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Course",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Top_Id",
                table: "Course",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Course_Top_Id",
                table: "Course",
                column: "Top_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Topic",
                table: "Course",
                column: "Top_Id",
                principalTable: "Topic",
                principalColumn: "Top_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
