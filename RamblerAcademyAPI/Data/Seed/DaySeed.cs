using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public static class DaySeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Day>().HasData(
                new Day(1, "Sunday", 'U'),
                new Day(2, "Monday", 'M'),
                new Day(3, "Tuesday", 'T'),
                new Day(4, "Wednesday", 'W'),
                new Day(5, "Thursday", 'R'),
                new Day(6, "Friday", 'F'),
                new Day(7, "Saturday", 'S')
            );
        }
    }
}
