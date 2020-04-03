using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class CourseSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(
                new Course("MAT010", "College Algebra"),
                new Course("MAT100", "Pre-Calculus"),
                new Course("MAT400", "Calculus I"),
                new Course("MAT250", "Summer Math Camp")
            );
        }
    }
}
