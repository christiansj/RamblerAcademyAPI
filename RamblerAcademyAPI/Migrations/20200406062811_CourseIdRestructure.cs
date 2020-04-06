using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace RamblerAcademyAPI.Migrations
{
    public partial class CourseIdRestructure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM \"Course\"", true);
            migrationBuilder.Sql("DELETE FROM \"CourseSection\"", true);

           

            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Course",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CourseNumber", "Name", "SubjectAbbreviation", "SubjectId" },
                values: new object[,]
                {
                    { 1, 10, "College Algebra", null, 0 },
                    { 2, 100, "Pre-Calculus", null, 0 },
                    { 3, 400, "Calculus I", null, 0 },
                    { 4, 250, "Summer Math Camp", null, 0 },
                    { 5, 200, "Early Civilizations", null, 0 },
                    { 6, 500, "American History - Pre Civil War", null, 0 },
                    { 7, 600, "American History - Post Civil War", null, 0 }
                });

            migrationBuilder.UpdateData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 28539,
                column: "CourseId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 57494,
                column: "CourseId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 59256,
                column: "CourseId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 78934,
                column: "CourseId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 94583,
                column: "CourseId",
                value: 6);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSection_Course_CourseId",
                table: "CourseSection",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSection_Course_CourseId",
                table: "CourseSection");

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Course",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Course");

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "CourseSection",
                type: "text",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Course",
                type: "text",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Id", "CourseNumber", "Name", "SubjectAbbreviation" },
                values: new object[,]
                {
                    { "MAT010", 10, "College Algebra", "MAT" },
                    { "MAT100", 100, "Pre-Calculus", "MAT" },
                    { "MAT400", 400, "Calculus I", "MAT" },
                    { "MAT250", 250, "Summer Math Camp", "MAT" },
                    { "HIS200", 200, "Early Civilizations", "HIS" },
                    { "HIS500", 500, "American History - Pre Civil War", "HIS" },
                    { "HIS600", 600, "American History - Post Civil War", "HIS" }
                });

            migrationBuilder.UpdateData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 28539,
                column: "CourseId",
                value: "MAT250");

            migrationBuilder.UpdateData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 57494,
                column: "CourseId",
                value: "MAT010");

            migrationBuilder.UpdateData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 59256,
                column: "CourseId",
                value: "MAT100");

            migrationBuilder.UpdateData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 78934,
                column: "CourseId",
                value: "HIS200");

            migrationBuilder.UpdateData(
                table: "CourseSection",
                keyColumn: "CourseReferenceNumber",
                keyValue: 94583,
                column: "CourseId",
                value: "HIS500");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSection_Course_CourseId",
                table: "CourseSection",
                column: "CourseId",
                principalTable: "Course",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
