using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class CourseCleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Subject_SubjectAbbreviation",
                table: "Course");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Subject_Abbreviation",
                table: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Course_SubjectAbbreviation",
                table: "Course");

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 28539);

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 57494, 3, 2 });

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 57494, 5, 2 });

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 59256, 3, 3 });

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 59256, 5, 3 });

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 78934, 3, 5 });

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 78934, 5, 5 });

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 94583, 3, 6 });

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 94583, 5, 6 });

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 57494);

            migrationBuilder.DeleteData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 59256);

            migrationBuilder.DeleteData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 78934);

            migrationBuilder.DeleteData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 94583);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "SubjectAbbreviation",
                table: "Course");

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                table: "Subject",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(3)",
                oldMaxLength: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Course_SubjectId",
                table: "Course",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Subject_SubjectId",
                table: "Course",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Subject_SubjectId",
                table: "Course");

            migrationBuilder.DropIndex(
                name: "IX_Course_SubjectId",
                table: "Course");

            migrationBuilder.AlterColumn<string>(
                name: "Abbreviation",
                table: "Subject",
                type: "character varying(3)",
                maxLength: 3,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 3,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SubjectAbbreviation",
                table: "Course",
                type: "character varying(3)",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Subject_Abbreviation",
                table: "Subject",
                column: "Abbreviation");

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CourseNumber", "Name", "SubjectAbbreviation", "SubjectId" },
                values: new object[,]
                {
                    { 1, 10, "College Algebra", null, 0 },
                    { 2, 100, "Pre-Calculus", null, 0 },
                    { 3, 400, "Calculus I", null, 0 },
                    { 4, 250, "Summer Math Camp", null, 0 },
                    { 5, 200, "Early Civilizations", null, 0 },
                    { 6, 500, "American History - Pre Civil War", null, 0 },
                    { 7, 600, "American History - Post Civil War", null, 0 }
                });

            migrationBuilder.InsertData(
                table: "CourseSection",
                columns: new[] { "CourseReferenceNumber", "ClassroomId", "CourseId", "FinalExamDate", "SectionNumber", "SemesterId" },
                values: new object[,]
                {
                    { 57494, 1, 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 59256, 2, 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 28539, 1, 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 78934, 7, 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 94583, 8, 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "CourseSectionTimeSlot",
                columns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                values: new object[,]
                {
                    { 57494, 3, 2 },
                    { 57494, 5, 2 },
                    { 59256, 3, 3 },
                    { 59256, 5, 3 },
                    { 78934, 3, 5 },
                    { 78934, 5, 5 },
                    { 94583, 3, 6 },
                    { 94583, 5, 6 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Course_SubjectAbbreviation",
                table: "Course",
                column: "SubjectAbbreviation");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Subject_SubjectAbbreviation",
                table: "Course",
                column: "SubjectAbbreviation",
                principalTable: "Subject",
                principalColumn: "Abbreviation",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
