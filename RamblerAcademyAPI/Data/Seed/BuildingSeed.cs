using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;


namespace RamblerAcademyAPI.Data.Seed
{
    public class BuildingSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Building>().HasData(
                new Building(1, "Main Building"),
                new Building(2, "Johnson Arts Building"),
                new Building(3, "Welch Building")
            );
        }
    }
}
