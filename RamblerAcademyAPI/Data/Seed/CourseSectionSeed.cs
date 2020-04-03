using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class CourseSectionSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<CourseSection>().HasData(
                new CourseSection(57494, 1, "MAT010", 1, 1),
                new CourseSection(59256, 1, "MAT100", 1, 2),
                new CourseSection(28539, 1, "MAT250", 1, 1)
           );
        }
    }
}
