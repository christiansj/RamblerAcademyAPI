using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class ModifiedUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AbcId",
                table: "User",
                maxLength: 6,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_AbcId",
                table: "User",
                column: "AbcId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_User_AbcId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "AbcId",
                table: "User");
        }
    }
}
