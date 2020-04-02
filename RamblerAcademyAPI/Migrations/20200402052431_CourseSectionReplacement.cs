using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RamblerAcademyAPI.Migrations
{
    public partial class CourseSectionReplacement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSemester");

            migrationBuilder.CreateTable(
                name: "CourseSection",
                columns: table => new
                {
                    CourseReferenceNumber = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId = table.Column<string>(nullable: true),
                    SemesterId = table.Column<int>(nullable: false),
                    SectionNumber = table.Column<int>(nullable: false),
                    ClassroomId = table.Column<int>(nullable: false),
                    FinalExamDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSection", x => x.CourseReferenceNumber);
                    table.ForeignKey(
                        name: "FK_CourseSection_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CourseSection_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CourseSection",
                columns: new[] { "CourseReferenceNumber", "ClassroomId", "CourseId", "FinalExamDate", "SectionNumber", "SemesterId" },
                values: new object[,]
                {
                    { 57494, 1, "MAT010", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 59256, 2, "MAT100", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 28539, 1, "MAT250", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSection_SemesterId",
                table: "CourseSection",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseSection_CourseId_SectionNumber_SemesterId",
                table: "CourseSection",
                columns: new[] { "CourseId", "SectionNumber", "SemesterId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSection");

            migrationBuilder.CreateTable(
                name: "CourseSemester",
                columns: table => new
                {
                    CourseId = table.Column<string>(type: "text", nullable: false),
                    SemesterId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSemester", x => new { x.CourseId, x.SemesterId });
                    table.ForeignKey(
                        name: "FK_CourseSemester_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Course",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSemester_Semester_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "Semester",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CourseSemester_SemesterId",
                table: "CourseSemester",
                column: "SemesterId");
        }
    }
}
