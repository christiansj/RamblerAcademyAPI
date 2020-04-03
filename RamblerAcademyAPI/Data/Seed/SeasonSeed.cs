using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class SeasonSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Season>().HasData(
                NewSeason(1, "Spring"),
                NewSeason(2, "Summer"),
                NewSeason(3, "Fall")
                );
        }

        private static  Season NewSeason(int Id, string Name)
        {
            return new Season
            {
                Id = Id,
                Name = Name
            };
        }
    }
}
