using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addCategoryIntoCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "category_id",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseCategories",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_active = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseCategories", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Courses_category_id",
                table: "Courses",
                column: "category_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CourseCategories_category_id",
                table: "Courses",
                column: "category_id",
                principalTable: "CourseCategories",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CourseCategories_category_id",
                table: "Courses");

            migrationBuilder.DropTable(
                name: "CourseCategories");

            migrationBuilder.DropIndex(
                name: "IX_Courses_category_id",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "Courses");
        }
    }
}
