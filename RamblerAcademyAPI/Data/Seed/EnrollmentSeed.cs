using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class EnrollmentSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Enrollment>().HasData(
                new Enrollment(57494, 1),
                new Enrollment(57494, 2),
                new Enrollment(57494, 3)
            );
        }
    }
}
