using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class CourseSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(
                NewCourse("MAT010", "College Algebra"),
                NewCourse("MAT100", "Pre-Calculus"),
                NewCourse("MAT400", "Calculus I"),
                NewCourse("MAT250", "Summer Math Camp")
                ) ;
        }

        private static Course NewCourse(string Id, string Name)
        {
            return new Course
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
