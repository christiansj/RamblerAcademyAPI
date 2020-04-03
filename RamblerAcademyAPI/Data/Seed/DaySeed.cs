using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public static class DaySeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Day>().HasData(
                new Day(1, "Sunday"),
                new Day(2, "Monday"),
                new Day(3, "Tuesday"),
                new Day(4, "Wednesday"),
                new Day(5, "Thursday"),
                new Day(6, "Friday"),
                new Day(7, "Saturday")
            );
        }
    }
}
