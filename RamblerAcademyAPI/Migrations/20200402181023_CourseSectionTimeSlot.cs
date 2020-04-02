using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class CourseSectionTimeSlot : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CourseSectionTimeSlot",
                columns: table => new
                {
                    CourseReferenceNumber = table.Column<int>(nullable: false),
                    DayId = table.Column<int>(nullable: false),
                    TimeSlotId = table.Column<int>(nullable: false),
                    DayTimeSlotDayId = table.Column<int>(nullable: true),
                    DayTimeSlotTimeSlotId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseSectionTimeSlots", x => new { x.CourseReferenceNumber, x.DayId, x.TimeSlotId });
                    table.ForeignKey(
                        name: "FK_CourseSectionTimeSlots_CourseSection_CourseReferenceNumber",
                        column: x => x.CourseReferenceNumber,
                        principalTable: "CourseSection",
                        principalColumn: "CourseReferenceNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseSectionTimeSlots_DayTimeSlot_DayTimeSlotDayId_DayTime~",
                        columns: x => new { x.DayTimeSlotDayId, x.DayTimeSlotTimeSlotId },
                        principalTable: "DayTimeSlot",
                        principalColumns: new[] { "DayId", "TimeSlotId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseSectionTimeSlots_DayTimeSlotDayId_DayTimeSlotTimeSlot~",
                table: "CourseSectionTimeSlot",
                columns: new[] { "DayTimeSlotDayId", "DayTimeSlotTimeSlotId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseSectionTimeSlot");
        }
    }
}
