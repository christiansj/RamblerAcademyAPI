using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class CourseSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(
                new Course(1, 10, "College Algebra", 1),
                new Course(2, 100, "Pre-Calculus", 1),
                new Course(3, 400, "Calculus I", 1),
                new Course(4, 250, "Summer Math Camp", 1),

                new Course(5, 200, "Early Civilizations", 2),
                new Course(6, 500, "American History - Pre Civil War", 2),
                new Course(7, 600, "American History - Post Civil War", 2)
            );
        }
    }
}
