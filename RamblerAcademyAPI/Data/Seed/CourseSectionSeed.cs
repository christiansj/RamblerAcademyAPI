using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class CourseSectionSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<CourseSection>().HasData(
                new CourseSection
                {
                    CourseReferenceNumber = 57494,
                    CourseId = "MAT010",
                    SemesterId = 1,
                    SectionNumber = 1,
                    ClassroomId = 1
                },
                new CourseSection
                {
                    CourseReferenceNumber = 59256,
                    CourseId = "MAT100",
                    SemesterId = 1,
                    SectionNumber = 1,
                    ClassroomId = 2
                },
                new CourseSection
                {
                    CourseReferenceNumber = 28539,
                    CourseId = "MAT250",
                    SemesterId = 2,
                    SectionNumber = 1,
                    ClassroomId = 1
                }
                );
        }
    }
}
