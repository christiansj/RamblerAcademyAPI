using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class SeedCourses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "MAT010", "College Algebra" },
                    { "MAT100", "Pre-Calculus" },
                    { "MAT400", "Calculus I" },
                    { "MAT250", "Summer Math Camp" }
                });

            migrationBuilder.UpdateData(
                table: "Semester",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2010, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Semester",
                columns: new[] { "Id", "EndDate", "SeasonId", "StartDate", "Year" },
                values: new object[] { 3, new DateTime(2010, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2010, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2010 });

            migrationBuilder.InsertData(
                table: "CourseSemester",
                columns: new[] { "CourseId", "SemesterId" },
                values: new object[,]
                {
                    { "MAT010", 1 },
                    { "MAT100", 1 },
                    { "MAT400", 1 },
                    { "MAT250", 2 },
                    { "MAT010", 3 },
                    { "MAT100", 3 },
                    { "MAT400", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseSemester",
                keyColumns: new[] { "CourseId", "SemesterId" },
                keyValues: new object[] { "MAT010", 1 });

            migrationBuilder.DeleteData(
                table: "CourseSemester",
                keyColumns: new[] { "CourseId", "SemesterId" },
                keyValues: new object[] { "MAT010", 3 });

            migrationBuilder.DeleteData(
                table: "CourseSemester",
                keyColumns: new[] { "CourseId", "SemesterId" },
                keyValues: new object[] { "MAT100", 1 });

            migrationBuilder.DeleteData(
                table: "CourseSemester",
                keyColumns: new[] { "CourseId", "SemesterId" },
                keyValues: new object[] { "MAT100", 3 });

            migrationBuilder.DeleteData(
                table: "CourseSemester",
                keyColumns: new[] { "CourseId", "SemesterId" },
                keyValues: new object[] { "MAT250", 2 });

            migrationBuilder.DeleteData(
                table: "CourseSemester",
                keyColumns: new[] { "CourseId", "SemesterId" },
                keyValues: new object[] { "MAT400", 1 });

            migrationBuilder.DeleteData(
                table: "CourseSemester",
                keyColumns: new[] { "CourseId", "SemesterId" },
                keyValues: new object[] { "MAT400", 3 });

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "MAT010");

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "MAT100");

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "MAT250");

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "MAT400");

            migrationBuilder.DeleteData(
                table: "Semester",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Semester",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2010, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
