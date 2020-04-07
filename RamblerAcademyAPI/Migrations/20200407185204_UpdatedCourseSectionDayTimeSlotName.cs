using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class UpdatedCourseSectionDayTimeSlotName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSectionTimeSlot");

            migrationBuilder.CreateTable(
                name: "CourseSectionDayTimeSlot",
                columns: table => new
                {
                    CourseReferenceNumber = table.Column<int>(nullable: false),
                    DayId = table.Column<int>(nullable: false),
                    TimeSlotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSectionDayTimeSlot", x => new { x.CourseReferenceNumber, x.DayId, x.TimeSlotId });
                    table.ForeignKey(
                        name: "FK_CourseSectionDayTimeSlot_CourseSection_CourseReferenceNumber",
                        column: x => x.CourseReferenceNumber,
                        principalTable: "CourseSection",
                        principalColumn: "CourseReferenceNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSectionDayTimeSlot_DayTimeSlot_DayId_TimeSlotId",
                        columns: x => new { x.DayId, x.TimeSlotId },
                        principalTable: "DayTimeSlot",
                        principalColumns: new[] { "DayId", "TimeSlotId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CourseSectionDayTimeSlot",
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
                name: "IX_CourseSectionDayTimeSlot_DayId_TimeSlotId",
                table: "CourseSectionDayTimeSlot",
                columns: new[] { "DayId", "TimeSlotId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSectionDayTimeSlot");

            migrationBuilder.CreateTable(
                name: "CourseSectionTimeSlot",
                columns: table => new
                {
                    CourseReferenceNumber = table.Column<int>(type: "integer", nullable: false),
                    DayId = table.Column<int>(type: "integer", nullable: false),
                    TimeSlotId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSectionTimeSlot", x => new { x.CourseReferenceNumber, x.DayId, x.TimeSlotId });
                    table.ForeignKey(
                        name: "FK_CourseSectionTimeSlot_CourseSection_CourseReferenceNumber",
                        column: x => x.CourseReferenceNumber,
                        principalTable: "CourseSection",
                        principalColumn: "CourseReferenceNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSectionTimeSlot_DayTimeSlot_DayId_TimeSlotId",
                        columns: x => new { x.DayId, x.TimeSlotId },
                        principalTable: "DayTimeSlot",
                        principalColumns: new[] { "DayId", "TimeSlotId" },
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_CourseSectionTimeSlot_DayId_TimeSlotId",
                table: "CourseSectionTimeSlot",
                columns: new[] { "DayId", "TimeSlotId" });
        }
    }
}
