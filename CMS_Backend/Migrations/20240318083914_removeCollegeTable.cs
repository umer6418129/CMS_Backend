using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class removeCollegeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CollegeFaciliteis_Colleges_collegeId",
                table: "CollegeFaciliteis");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactUs_Colleges_collegeId",
                table: "ContactUs");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_Colleges_collegeId",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentInfos_Colleges_collegeId",
                table: "StudentInfos");

            migrationBuilder.DropForeignKey(
                name: "FK_user_roles_Colleges_CollegeId",
                table: "user_roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Colleges_collegeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_collegeId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_user_roles_CollegeId",
                table: "user_roles");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfos_collegeId",
                table: "StudentInfos");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_collegeId",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_ContactUs_collegeId",
                table: "ContactUs");

            migrationBuilder.DropIndex(
                name: "IX_CollegeFaciliteis_collegeId",
                table: "CollegeFaciliteis");

            migrationBuilder.DropColumn(
                name: "collegeId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CollegeId",
                table: "user_roles");

            migrationBuilder.DropColumn(
                name: "collegeId",
                table: "StudentInfos");

            migrationBuilder.DropColumn(
                name: "collegeId",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "collegeId",
                table: "ContactUs");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "collegeId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CollegeId",
                table: "user_roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "collegeId",
                table: "StudentInfos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "collegeId",
                table: "Feedbacks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "collegeId",
                table: "ContactUs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_collegeId",
                table: "Users",
                column: "collegeId");

            migrationBuilder.CreateIndex(
                name: "IX_user_roles_CollegeId",
                table: "user_roles",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfos_collegeId",
                table: "StudentInfos",
                column: "collegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_collegeId",
                table: "Feedbacks",
                column: "collegeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_collegeId",
                table: "ContactUs",
                column: "collegeId");

            migrationBuilder.CreateIndex(
                name: "IX_CollegeFaciliteis_collegeId",
                table: "CollegeFaciliteis",
                column: "collegeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CollegeFaciliteis_Colleges_collegeId",
                table: "CollegeFaciliteis",
                column: "collegeId",
                principalTable: "Colleges",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactUs_Colleges_collegeId",
                table: "ContactUs",
                column: "collegeId",
                principalTable: "Colleges",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_Colleges_collegeId",
                table: "Feedbacks",
                column: "collegeId",
                principalTable: "Colleges",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInfos_Colleges_collegeId",
                table: "StudentInfos",
                column: "collegeId",
                principalTable: "Colleges",
                principalColumn: "id");

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
        }
    }
}
