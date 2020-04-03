using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class TimeSlotSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 57494, 1, 2 });

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 59256, 2, 1 });

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 59256, 4, 1 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { "HIS200", "Early Civilizations" },
                    { "HIS500", "American History - Pre Civil War" },
                    { "HIS600", "American History - Post Civil War" }
                });

            migrationBuilder.InsertData(
                table: "DayTimeSlot",
                columns: new[] { "DayId", "TimeSlotId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 5, 1 },
                    { 5, 2 }
                });

            migrationBuilder.UpdateData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 10, 15, 0, 0), new TimeSpan(0, 9, 0, 0, 0) });

            migrationBuilder.InsertData(
                table: "TimeSlot",
                columns: new[] { "Id", "EndTime", "StartTime" },
                values: new object[,]
                {
                    { 4, new TimeSpan(0, 14, 15, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 5, new TimeSpan(0, 15, 45, 0, 0), new TimeSpan(0, 14, 30, 0, 0) },
                    { 6, new TimeSpan(0, 17, 15, 0, 0), new TimeSpan(0, 16, 0, 0, 0) },
                    { 17, new TimeSpan(0, 17, 50, 0, 0), new TimeSpan(0, 17, 0, 0, 0) },
                    { 8, new TimeSpan(0, 20, 15, 0, 0), new TimeSpan(0, 19, 0, 0, 0) },
                    { 9, new TimeSpan(0, 9, 50, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 10, new TimeSpan(0, 10, 50, 0, 0), new TimeSpan(0, 10, 0, 0, 0) },
                    { 11, new TimeSpan(0, 11, 50, 0, 0), new TimeSpan(0, 11, 0, 0, 0) },
                    { 12, new TimeSpan(0, 12, 50, 0, 0), new TimeSpan(0, 12, 0, 0, 0) },
                    { 13, new TimeSpan(0, 13, 50, 0, 0), new TimeSpan(0, 13, 0, 0, 0) },
                    { 14, new TimeSpan(0, 14, 50, 0, 0), new TimeSpan(0, 14, 0, 0, 0) },
                    { 15, new TimeSpan(0, 15, 50, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 16, new TimeSpan(0, 16, 50, 0, 0), new TimeSpan(0, 16, 0, 0, 0) },
                    { 3, new TimeSpan(0, 12, 45, 0, 0), new TimeSpan(0, 11, 30, 0, 0) },
                    { 7, new TimeSpan(0, 18, 45, 0, 0), new TimeSpan(0, 17, 30, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "CourseSectionTimeSlot",
                columns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                values: new object[] { 57494, 5, 2 });

            migrationBuilder.InsertData(
                table: "DayTimeSlot",
                columns: new[] { "DayId", "TimeSlotId" },
                values: new object[,]
                {
                    { 2, 12 },
                    { 4, 12 },
                    { 6, 12 },
                    { 2, 13 },
                    { 4, 13 },
                    { 6, 13 },
                    { 2, 14 },
                    { 6, 11 },
                    { 4, 14 },
                    { 2, 15 },
                    { 4, 15 },
                    { 6, 15 },
                    { 2, 16 },
                    { 4, 16 },
                    { 6, 16 },
                    { 2, 17 },
                    { 6, 14 },
                    { 4, 11 },
                    { 2, 11 },
                    { 6, 10 },
                    { 3, 3 },
                    { 5, 3 },
                    { 3, 4 },
                    { 5, 4 },
                    { 3, 5 },
                    { 5, 5 },
                    { 3, 6 },
                    { 5, 6 },
                    { 3, 7 },
                    { 5, 7 },
                    { 3, 8 },
                    { 5, 8 },
                    { 2, 9 },
                    { 4, 9 },
                    { 6, 9 },
                    { 2, 10 },
                    { 4, 10 },
                    { 4, 17 },
                    { 6, 17 }
                });

            migrationBuilder.InsertData(
                table: "CourseSectionTimeSlot",
                columns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                values: new object[,]
                {
                    { 59256, 3, 3 },
                    { 59256, 5, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "HIS200");

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "HIS500");

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "HIS600");

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
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 2, 10 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 2, 11 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 2, 12 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 2, 13 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 2, 14 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 2, 15 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 2, 16 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 2, 17 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 3, 5 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 3, 6 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 4, 9 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 4, 10 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 4, 12 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 4, 13 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 4, 14 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 4, 15 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 4, 17 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 6, 9 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 6, 10 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 6, 11 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 6, 12 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 6, 13 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 6, 14 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 6, 15 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 6, 16 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 6, 17 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 5, 2 });

            migrationBuilder.DeleteData(
                table: "DayTimeSlot",
                keyColumns: new[] { "DayId", "TimeSlotId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "DayTimeSlot",
                columns: new[] { "DayId", "TimeSlotId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 4, 1 }
                });

            migrationBuilder.UpdateData(
                table: "TimeSlot",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new TimeSpan(0, 12, 45, 0, 0), new TimeSpan(0, 11, 30, 0, 0) });

            migrationBuilder.InsertData(
                table: "CourseSectionTimeSlot",
                columns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                values: new object[,]
                {
                    { 57494, 1, 2 },
                    { 59256, 2, 1 },
                    { 59256, 4, 1 }
                });
        }
    }
}
