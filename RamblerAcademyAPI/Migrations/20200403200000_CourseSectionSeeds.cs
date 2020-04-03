using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class CourseSectionSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Welch Humanities");

            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "Rodney Sciences" });

            migrationBuilder.InsertData(
                table: "Classroom",
                columns: new[] { "Id", "BuildingId", "Floor", "HallwayNumber", "RoomNumber" },
                values: new object[,]
                {
                    { 7, 2, 1, 1, 2 },
                    { 8, 2, 1, 1, 7 }
                });

            migrationBuilder.InsertData(
                table: "Classroom",
                columns: new[] { "Id", "BuildingId", "Floor", "HallwayNumber", "RoomNumber" },
                values: new object[,]
                {
                    { 3, 4, 1, 1, 10 },
                    { 4, 4, 1, 1, 20 },
                    { 5, 4, 1, 2, 32 },
                    { 6, 4, 1, 2, 43 }
                });

            migrationBuilder.InsertData(
                table: "CourseSection",
                columns: new[] { "CourseReferenceNumber", "ClassroomId", "CourseId", "FinalExamDate", "SectionNumber", "SemesterId" },
                values: new object[,]
                {
                    { 78934, 7, "HIS200", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 94583, 8, "HIS500", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "CourseSectionTimeSlot",
                columns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                values: new object[,]
                {
                    { 78934, 3, 5 },
                    { 78934, 5, 5 },
                    { 94583, 3, 6 },
                    { 94583, 5, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 6);

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
                table: "Building",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 78934);

            migrationBuilder.DeleteData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 94583);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Welch Building");
        }
    }
}
