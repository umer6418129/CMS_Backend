using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class addSubjectsIntoCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_active",
                table: "Subjects",
                type: "bit",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CourseSubjects",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_id = table.Column<int>(type: "int", nullable: false),
                    subject_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSubjects", x => x.id);
                    table.ForeignKey(
                        name: "FK_CourseSubjects_Courses_course_id",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSubjects_Subjects_subject_id",
                        column: x => x.subject_id,
                        principalTable: "Subjects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_course_id",
                table: "CourseSubjects",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSubjects_subject_id",
                table: "CourseSubjects",
                column: "subject_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSubjects");

            migrationBuilder.DropColumn(
                name: "is_active",
                table: "Subjects");
        }
    }
}
