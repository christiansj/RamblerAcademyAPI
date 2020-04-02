using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class CourseSectionTimeSlotSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionTimeSlots_DayTimeSlot_DayTimeSlotDayId_DayTime~",
                table: "CourseSectionTimeSlot");

            migrationBuilder.DropIndex(
                name: "IX_CourseSectionTimeSlots_DayTimeSlotDayId_DayTimeSlotTimeSlot~",
                table: "CourseSectionTimeSlot");

            migrationBuilder.DropColumn(
                name: "DayTimeSlotDayId",
                table: "CourseSectionTimeSlot");

            migrationBuilder.DropColumn(
                name: "DayTimeSlotTimeSlotId",
                table: "CourseSectionTimeSlot");

            migrationBuilder.InsertData(
                table: "CourseSectionTimeSlot",
                columns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                values: new object[,]
                {
                    { 57494, 1, 2 },
                    { 57494, 3, 2 },
                    { 59256, 2, 1 },
                    { 59256, 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionTimeSlots_DayId_TimeSlotId",
                table: "CourseSectionTimeSlot",
                columns: new[] { "DayId", "TimeSlotId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionTimeSlots_DayTimeSlot_DayId_TimeSlotId",
                table: "CourseSectionTimeSlot",
                columns: new[] { "DayId", "TimeSlotId" },
                principalTable: "DayTimeSlot",
                principalColumns: new[] { "DayId", "TimeSlotId" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSectionTimeSlots_DayTimeSlot_DayId_TimeSlotId",
                table: "CourseSectionTimeSlot");

            migrationBuilder.DropIndex(
                name: "IX_CourseSectionTimeSlots_DayId_TimeSlotId",
                table: "CourseSectionTimeSlot");

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 57494, 1, 2 });

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 57494, 3, 2 });

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 59256, 2, 1 });

            migrationBuilder.DeleteData(
                table: "CourseSectionTimeSlot",
                keyColumns: new[] { "CourseReferenceNumber", "DayId", "TimeSlotId" },
                keyValues: new object[] { 59256, 4, 1 });

            migrationBuilder.AddColumn<int>(
                name: "DayTimeSlotDayId",
                table: "CourseSectionTimeSlot",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DayTimeSlotTimeSlotId",
                table: "CourseSectionTimeSlot",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionTimeSlots_DayTimeSlotDayId_DayTimeSlotTimeSlot~",
                table: "CourseSectionTimeSlot",
                columns: new[] { "DayTimeSlotDayId", "DayTimeSlotTimeSlotId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSectionTimeSlots_DayTimeSlot_DayTimeSlotDayId_DayTime~",
                table: "CourseSectionTimeSlot",
                columns: new[] { "DayTimeSlotDayId", "DayTimeSlotTimeSlotId" },
                principalTable: "DayTimeSlot",
                principalColumns: new[] { "DayId", "TimeSlotId" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
