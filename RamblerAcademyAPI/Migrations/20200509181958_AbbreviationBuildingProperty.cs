using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class AbbreviationBuildingProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abbreviation",
                table: "Building",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 1,
                column: "Abbreviation",
                value: "MB");

            migrationBuilder.UpdateData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 2,
                column: "Abbreviation",
                value: "JA");

            migrationBuilder.UpdateData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 3,
                column: "Abbreviation",
                value: "WH");

            migrationBuilder.UpdateData(
                table: "Building",
                keyColumn: "Id",
                keyValue: 4,
                column: "Abbreviation",
                value: "RS");

            migrationBuilder.CreateIndex(
                name: "IX_Building_Abbreviation",
                table: "Building",
                column: "Abbreviation",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Building_Abbreviation",
                table: "Building");

            migrationBuilder.DropColumn(
                name: "Abbreviation",
                table: "Building");
        }
    }
}
