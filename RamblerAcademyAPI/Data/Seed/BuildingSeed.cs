using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class BuildingSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Building>().HasData(
                new Building(1, "Main Building", "MB"),
                new Building(2, "Johnson Arts Building", "JA"),
                new Building(3, "Welch Humanities", "WH"),
                new Building(4, "Rodney Sciences", "RS")
            );
        }
    }
}
