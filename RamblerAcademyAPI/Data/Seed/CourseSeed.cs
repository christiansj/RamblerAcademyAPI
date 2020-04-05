using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class CourseSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(
                new Course("MAT", 10, "College Algebra"),
                new Course("MAT", 100, "Pre-Calculus"),
                new Course("MAT", 400, "Calculus I"),
                new Course("MAT", 250, "Summer Math Camp"),

                new Course("HIS", 200, "Early Civilizations"),
                new Course("HIS", 500, "American History - Pre Civil War"),
                new Course("HIS", 600, "American History - Post Civil War")
            );
        }
    }
}
