using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class createTblDepratmentsAndFacultyInfos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "FacultyInfos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    department_id = table.Column<int>(type: "int", nullable: true),
                    user_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacultyInfos", x => x.id);
                    table.ForeignKey(
                        name: "FK_FacultyInfos_Departments_department_id",
                        column: x => x.department_id,
                        principalTable: "Departments",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_FacultyInfos_Users_user_id",
                        column: x => x.user_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacultyInfos_department_id",
                table: "FacultyInfos",
                column: "department_id");

            migrationBuilder.CreateIndex(
                name: "IX_FacultyInfos_user_id",
                table: "FacultyInfos",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacultyInfos");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
