using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RamblerAcademyAPI.Models;
namespace RamblerAcademyAPI.Data.Seed
{
    public static class DaySeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Day>().HasData(
                new Day
                {
                    Id = 1,
                    Name = "Sunday"
                },
                new Day
                {
                    Id = 2,
                    Name = "Monday"
                },
                new Day
                {
                    Id = 3,
                    Name = "Tuesday"
                },
                new Day
                {
                    Id = 4,
                    Name = "Wednesday"
                },
                new Day
                {
                    Id = 5,
                    Name = "Thursday"
                },
                new Day
                {
                    Id = 6,
                    Name = "Friday"
                },
                new Day
                {
                    Id = 7,
                    Name = "Saturday"
                }
                );
        }
    }
}
