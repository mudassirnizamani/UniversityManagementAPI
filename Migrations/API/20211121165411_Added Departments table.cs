using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityManagementAPI.Migrations.API
{
    public partial class AddedDepartmentstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeadOfDepartmentId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseAdviserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FacultyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
