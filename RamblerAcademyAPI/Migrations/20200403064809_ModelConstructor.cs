using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class ModelConstructor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Johnson Arts Building");

            migrationBuilder.UpdateData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Welch Building");

            migrationBuilder.UpdateData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 28539,
                column: "SemesterId",
                value: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Johnson Arts");

            migrationBuilder.UpdateData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Welch Sciences");

            migrationBuilder.UpdateData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 28539,
                column: "SemesterId",
                value: 2);
        }
    }
}
