using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class one2manyInstCrsz : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.AlterColumn<int>(
            //    name: "Inst_Id",
            //    table: "Inst_Crs",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_Inst_Crs_Crs_Id",
                table: "Inst_Crs",
                column: "Crs_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inst_Crs_Course_Crs_Id",
                table: "Inst_Crs",
                column: "Crs_Id",
                principalTable: "Course",
                principalColumn: "Crs_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inst_Crs_Instructor_Inst_Id",
                table: "Inst_Crs",
                column: "Inst_Id",
                principalTable: "Instructor",
                principalColumn: "Inst_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inst_Crs_Course_Crs_Id",
                table: "Inst_Crs");

            migrationBuilder.DropForeignKey(
                name: "FK_Inst_Crs_Instructor_Inst_Id",
                table: "Inst_Crs");

            migrationBuilder.DropIndex(
                name: "IX_Inst_Crs_Crs_Id",
                table: "Inst_Crs");

            //migrationBuilder.AlterColumn<int>(
            //    name: "Inst_Id",
            //    table: "Inst_Crs",
            //    type: "int",
            //    nullable: false,
            //    oldClrType: typeof(int),
            //    oldType: "int")
            //    .Annotation("SqlServer:Identity", "1, 1");
        }
    }
}
