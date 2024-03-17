using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class createTblStudentInfoAndCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_colleges_CollegeId",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_users_colleges_collegeId",
                table: "users");

            migrationBuilder.DropForeignKey(
                name: "FK_users_user_roles_role_id",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_colleges",
                table: "colleges");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "colleges",
                newName: "Colleges");

            migrationBuilder.RenameIndex(
                name: "IX_users_role_id",
                table: "Users",
                newName: "IX_Users_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_users_collegeId",
                table: "Users",
                newName: "IX_Users_collegeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colleges",
                table: "Colleges",
                column: "id");

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    course_name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    std_unique_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    std_father_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    std_mother_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    std_date_of_birth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    std_residential_address = table.Column<string>(type: "TEXT", nullable: true),
                    std_permanent_address = table.Column<string>(type: "TEXT", nullable: true),
                    addmission_status = table.Column<int>(type: "int", nullable: false),
                    collegeId = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true),
                    course_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfos", x => x.id);
                    table.ForeignKey(
                        name: "FK_StudentInfos_Colleges_collegeId",
                        column: x => x.collegeId,
                        principalTable: "Colleges",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StudentInfos_Courses_course_id",
                        column: x => x.course_id,
                        principalTable: "Courses",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StudentInfos_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_collegeId",
                table: "StudentInfos",
                column: "collegeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_course_id",
                table: "StudentInfos",
                column: "course_id");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_user_id",
                table: "StudentInfos",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_Colleges_CollegeId",
                table: "user_roles",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Colleges_collegeId",
                table: "Users",
                column: "collegeId",
                principalTable: "Colleges",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_user_roles_role_id",
                table: "Users",
                column: "role_id",
                principalTable: "user_roles",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_Colleges_CollegeId",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Colleges_collegeId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_user_roles_role_id",
                table: "Users");

            migrationBuilder.DropTable(
                name: "StudentInfos");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colleges",
                table: "Colleges");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Colleges",
                newName: "colleges");

            migrationBuilder.RenameIndex(
                name: "IX_Users_role_id",
                table: "users",
                newName: "IX_users_role_id");

            migrationBuilder.RenameIndex(
                name: "IX_Users_collegeId",
                table: "users",
                newName: "IX_users_collegeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_colleges",
                table: "colleges",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_roles_colleges_CollegeId",
                table: "user_roles",
                column: "CollegeId",
                principalTable: "colleges",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_colleges_collegeId",
                table: "users",
                column: "collegeId",
                principalTable: "colleges",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_users_user_roles_role_id",
                table: "users",
                column: "role_id",
                principalTable: "user_roles",
                principalColumn: "id");
        }
    }
}
