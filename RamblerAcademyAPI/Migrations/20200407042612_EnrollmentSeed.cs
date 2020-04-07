using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class EnrollmentSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "CourseReferenceNumber", "StudentId" },
                values: new object[,]
                {
                    { 57494, 1L },
                    { 57494, 2L },
                    { 57494, 3L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumns: new[] { "CourseReferenceNumber", "StudentId" },
                keyValues: new object[] { 57494, 1L });

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumns: new[] { "CourseReferenceNumber", "StudentId" },
                keyValues: new object[] { 57494, 2L });

            migrationBuilder.DeleteData(
                table: "Enrollment",
                keyColumns: new[] { "CourseReferenceNumber", "StudentId" },
                keyValues: new object[] { 57494, 3L });
        }
    }
}
