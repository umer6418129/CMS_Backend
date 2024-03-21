using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addCourseIdIntoFeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "courseId",
                table: "Feedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_courseId",
                table: "Feedbacks",
                column: "courseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Courses_courseId",
                table: "Feedbacks",
                column: "courseId",
                principalTable: "Courses",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Courses_courseId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_courseId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "courseId",
                table: "Feedbacks");
        }
    }
}
