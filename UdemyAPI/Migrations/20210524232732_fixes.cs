using Microsoft.EntityFrameworkCore.Migrations;

namespace UdemyAPI.Migrations
{
    public partial class fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
      

  

    
      
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "supCategorySubCatId",
                table: "Topic",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SupCategories",
                columns: table => new
                {
                    SubCatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupCategories", x => x.SubCatId);
                    table.ForeignKey(
                        name: "FK_SupCategories_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Category_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topic_supCategorySubCatId",
                table: "Topic",
                column: "supCategorySubCatId");

            migrationBuilder.CreateIndex(
                name: "IX_SupCategories_CategoryId",
                table: "SupCategories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_SupCategories_supCategorySubCatId",
                table: "Topic",
                column: "supCategorySubCatId",
                principalTable: "SupCategories",
                principalColumn: "SubCatId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
