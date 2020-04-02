using Microsoft.EntityFrameworkCore.Migrations;

namespace RamblerAcademyAPI.Migrations
{
    public partial class CourseSectionFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CourseSection_ClassroomId",
                table: "CourseSection",
                column: "ClassroomId");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseSection_Classroom_ClassroomId",
                table: "CourseSection",
                column: "ClassroomId",
                principalTable: "Classroom",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseSection_Classroom_ClassroomId",
                table: "CourseSection");

            migrationBuilder.DropIndex(
                name: "IX_CourseSection_ClassroomId",
                table: "CourseSection");
        }
    }
}
