using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class testit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_ShoppingCard_ShoppingCardCardId",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Topic_TopId",
                table: "Course");

            migrationBuilder.DropTable(
                name: "ShoppingCard");

            migrationBuilder.DropIndex(
                name: "IX_Course_ShoppingCardCardId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "ShoppingCardCardId",
                table: "Course");

            migrationBuilder.RenameColumn(
                name: "TopId",
                table: "Course",
                newName: "Top_Id");

            migrationBuilder.RenameColumn(
                name: "CrsId",
                table: "Course",
                newName: "Crs_Id");

            migrationBuilder.RenameIndex(
                name: "IX_Course_TopId",
                table: "Course",
                newName: "IX_Course_Top_Id");

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
