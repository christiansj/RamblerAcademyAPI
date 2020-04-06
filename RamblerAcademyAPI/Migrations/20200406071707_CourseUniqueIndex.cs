using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class CourseUniqueIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Course_SubjectId",
                table: "Course");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SubjectId_CourseNumber",
                table: "Course",
                columns: new[] { "SubjectId", "CourseNumber" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Course_SubjectId_CourseNumber",
                table: "Course");

            migrationBuilder.CreateIndex(
                name: "IX_Course_SubjectId",
                table: "Course",
                column: "SubjectId");
        }
    }
}
