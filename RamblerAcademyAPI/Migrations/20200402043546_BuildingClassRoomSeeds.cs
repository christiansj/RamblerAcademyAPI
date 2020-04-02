using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class BuildingClassRoomSeeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Building",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Main Building" },
                    { 2, "Johnson Arts" },
                    { 3, "Welch Sciences" }
                });

            migrationBuilder.InsertData(
                table: "Classroom",
                columns: new[] { "Id", "BuildingId", "Floor", "HallwayNumber", "RoomNumber" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 12 },
                    { 2, 1, 1, 1, 14 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
