using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class SeedSemester : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Semester",
                columns: new[] { "Id", "EndDate", "SeasonId", "StartDate", "Year" },
                values: new object[,]
                {
                    { 1, new DateTime(2010, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2010, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2010 },
                    { 2, new DateTime(2010, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2010, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2010 }
                });
            migrationBuilder.RenameTable("Courses", "Course");
            migrationBuilder.RenameTable("Students", "Student");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Semester",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Semester",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable("Course", "Courses");
            migrationBuilder.RenameTable("Student", "Students");
        }
    }
}
