using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class DayTimeSlotModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DayTimeSlot",
                columns: table => new
                {
                    DayId = table.Column<int>(nullable: false),
                    TimeSlotId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayTimeSlot", x => new { x.DayId, x.TimeSlotId });
                    table.ForeignKey(
                        name: "FK_DayTimeSlot_Day_DayId",
                        column: x => x.DayId,
                        principalTable: "Day",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayTimeSlot_TimeSlot_TimeSlotId",
                        column: x => x.TimeSlotId,
                        principalTable: "TimeSlot",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DayTimeSlot",
                columns: new[] { "DayId", "TimeSlotId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 3, 2 },
                    { 2, 1 },
                    { 4, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DayTimeSlot_TimeSlotId",
                table: "DayTimeSlot",
                column: "TimeSlotId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DayTimeSlot");
        }
    }
}
