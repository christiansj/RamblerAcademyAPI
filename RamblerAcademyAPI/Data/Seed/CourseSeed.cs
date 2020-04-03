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
                new Course("MAT250", "Summer Math Camp"),

                new Course("HIS200", "Early Civilizations"),
                new Course("HIS500", "American History - Pre Civil War"),
                new Course("HIS600", "American History - Post Civil War")
            );
        }
    }
}
