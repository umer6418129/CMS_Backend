using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addIsActiveTypeOfFaculty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "FacultyTypes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_active",
                table: "FacultyTypes");
        }
    }
}
