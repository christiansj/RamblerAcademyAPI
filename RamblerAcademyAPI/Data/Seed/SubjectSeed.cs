using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class SubjectSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Subject>().HasData(
                new Subject(1, "Mathematics", "MAT"),
                new Subject(2, "History", "HIS")
            );
        }
    }
}
