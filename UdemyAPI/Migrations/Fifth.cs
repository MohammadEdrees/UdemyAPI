using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class RefreshContext2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Inst_Name", "Instructor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
