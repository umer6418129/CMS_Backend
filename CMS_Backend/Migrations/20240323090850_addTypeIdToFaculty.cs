using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addTypeIdToFaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "faculty_type_id",
                table: "FacultyInfos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FacultyInfos_faculty_type_id",
                table: "FacultyInfos",
                column: "faculty_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_FacultyInfos_FacultyTypes_faculty_type_id",
                table: "FacultyInfos",
                column: "faculty_type_id",
                principalTable: "FacultyTypes",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacultyInfos_FacultyTypes_faculty_type_id",
                table: "FacultyInfos");

            migrationBuilder.DropIndex(
                name: "IX_FacultyInfos_faculty_type_id",
                table: "FacultyInfos");

            migrationBuilder.DropColumn(
                name: "faculty_type_id",
                table: "FacultyInfos");
        }
    }
}
