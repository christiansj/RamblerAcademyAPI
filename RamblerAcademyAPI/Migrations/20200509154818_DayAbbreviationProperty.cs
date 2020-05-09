using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class DayAbbreviationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<char>(
                name: "Abbreviation",
                table: "Day",
                nullable: false,
                defaultValue: '?');

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: 1,
                column: "Abbreviation",
                value: 'U');

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: 2,
                column: "Abbreviation",
                value: 'M');

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: 3,
                column: "Abbreviation",
                value: 'T');

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: 4,
                column: "Abbreviation",
                value: 'W');

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: 5,
                column: "Abbreviation",
                value: 'R');

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: 6,
                column: "Abbreviation",
                value: 'F');

            migrationBuilder.UpdateData(
                table: "Day",
                keyColumn: "Id",
                keyValue: 7,
                column: "Abbreviation",
                value: 'S');

            migrationBuilder.CreateIndex(
                name: "IX_Day_Abbreviation",
                table: "Day",
                column: "Abbreviation",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Day_Abbreviation",
                table: "Day");

            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "Day");
        }
    }
}
