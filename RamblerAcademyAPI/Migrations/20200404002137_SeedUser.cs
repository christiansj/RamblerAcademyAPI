using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class SeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AbcId", "Email", "FirstName", "LastName", "Password", "RoleId" },
                values: new object[,]
                {
                    { 1L, "jvs374", "billBob@example.com", "Bill", "Bob", "password", 1 },
                    { 2L, "cwo479", "chrisRob@example.com", "Christopher", "Rob", "password", 1 },
                    { 3L, "mji389", "matty@example.com", "Matt", "More", "password", 1 },
                    { 4L, "fjo342", "sal@example.com", "Sally", "Eddy", "password", 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
