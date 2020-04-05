using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RamblerAcademyAPI.Migrations
{
    public partial class SubjectDataAndSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseNumber",
                table: "Course",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "SubjectAbbreviation",
                table: "Course",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Abbreviation = table.Column<string>(maxLength: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                    table.UniqueConstraint("AK_Subject_Abbreviation", x => x.Abbreviation);
                });

            migrationBuilder.InsertData(
                table: "Subject",
                columns: new[] { "Id", "Abbreviation", "Name" },
                values: new object[,]
                {
                    { 1, "MAT", "Mathematics" },
                    { 2, "HIS", "History" }
                });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "HIS200",
                columns: new[] { "CourseNumber", "SubjectAbbreviation" },
                values: new object[] { 200, "HIS" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "HIS500",
                columns: new[] { "CourseNumber", "SubjectAbbreviation" },
                values: new object[] { 500, "HIS" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "HIS600",
                columns: new[] { "CourseNumber", "SubjectAbbreviation" },
                values: new object[] { 600, "HIS" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "MAT010",
                columns: new[] { "CourseNumber", "SubjectAbbreviation" },
                values: new object[] { 10, "MAT" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "MAT100",
                columns: new[] { "CourseNumber", "SubjectAbbreviation" },
                values: new object[] { 100, "MAT" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "MAT250",
                columns: new[] { "CourseNumber", "SubjectAbbreviation" },
                values: new object[] { 250, "MAT" });

            migrationBuilder.UpdateData(
                table: "Course",
                keyColumn: "Id",
                keyValue: "MAT400",
                columns: new[] { "CourseNumber", "SubjectAbbreviation" },
                values: new object[] { 400, "MAT" });

            migrationBuilder.CreateIndex(
                name: "IX_Course_SubjectAbbreviation",
                table: "Course",
                column: "SubjectAbbreviation");

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Abbreviation",
                table: "Subject",
                column: "Abbreviation",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subject_Name",
                table: "Subject",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Subject_SubjectAbbreviation",
                table: "Course",
                column: "SubjectAbbreviation",
                principalTable: "Subject",
                principalColumn: "Abbreviation",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Subject_SubjectAbbreviation",
                table: "Course");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Course_SubjectAbbreviation",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "CourseNumber",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "SubjectAbbreviation",
                table: "Course");
        }
    }
}
