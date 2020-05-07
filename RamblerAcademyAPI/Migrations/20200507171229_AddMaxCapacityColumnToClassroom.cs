using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class AddMaxCapacityColumnToClassroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxCapacity",
                table: "Classroom",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 1,
                column: "MaxCapacity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaxCapacity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 3,
                column: "MaxCapacity",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 4,
                column: "MaxCapacity",
                value: 200);

            migrationBuilder.UpdateData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 5,
                column: "MaxCapacity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 6,
                column: "MaxCapacity",
                value: 30);

            migrationBuilder.UpdateData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 7,
                column: "MaxCapacity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Classroom",
                keyColumn: "Id",
                keyValue: 8,
                column: "MaxCapacity",
                value: 50);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxCapacity",
                table: "Classroom");
        }
    }
}
