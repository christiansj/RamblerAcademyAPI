using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;


namespace RamblerAcademyAPI.Data.Seed
{
    public class BuildingSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Building>().HasData(
                new Building
                {
                    Id = 1,
                    Name = "Main Building"
                },
                new Building
                {
                    Id = 2,
                    Name = "Johnson Arts"
                },
                new Building
                {
                    Id = 3,
                    Name = "Welch Sciences"
                }
                );
        }
    }
}
