using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_Backend.Migrations
{
    /// <inheritdoc />
    public partial class createTblFacitiesContactUsAndFeedback : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollegeFaciliteis",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true),
                    collegeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeFaciliteis", x => x.id);
                    table.ForeignKey(
                        name: "FK_CollegeFaciliteis_Colleges_collegeId",
                        column: x => x.collegeId,
                        principalTable: "Colleges",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "ContactUs",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    full_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    collegeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactUs", x => x.id);
                    table.ForeignKey(
                        name: "FK_ContactUs_Colleges_collegeId",
                        column: x => x.collegeId,
                        principalTable: "Colleges",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Feedbacks",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    std_id = table.Column<int>(type: "int", nullable: true),
                    collegeId = table.Column<int>(type: "int", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feedbacks", x => x.id);
                    table.ForeignKey(
                        name: "FK_Feedbacks_Colleges_collegeId",
                        column: x => x.collegeId,
                        principalTable: "Colleges",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Feedbacks_Users_std_id",
                        column: x => x.std_id,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CollegeFaciliteis_collegeId",
                table: "CollegeFaciliteis",
                column: "collegeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactUs_collegeId",
                table: "ContactUs",
                column: "collegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_collegeId",
                table: "Feedbacks",
                column: "collegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_std_id",
                table: "Feedbacks",
                column: "std_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CollegeFaciliteis");

            migrationBuilder.DropTable(
                name: "ContactUs");

            migrationBuilder.DropTable(
                name: "Feedbacks");
        }
    }
}
