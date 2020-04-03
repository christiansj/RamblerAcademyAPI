using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class SeasonSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Season>().HasData(
                new Season(1, "Spring"),
                new Season(2, "Summer"),
                new Season(3, "Fall")
            );
        }
    }
}
