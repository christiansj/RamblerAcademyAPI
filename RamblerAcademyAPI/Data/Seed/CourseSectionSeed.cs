using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class CourseSectionSeed
    {
        public static void Seed(ModelBuilder builder)
        {
           builder.Entity<CourseSection>().HasData(
                new CourseSection(57494, 1, 1, 1, 1),
                new CourseSection(59256, 1, 2, 1, 2),
                new CourseSection(28539, 1, 4, 1, 1),

                new CourseSection(78934, 1, 5, 1, 7),
                new CourseSection(94583, 1, 6, 1, 8) 
           );
        }
    }
}
