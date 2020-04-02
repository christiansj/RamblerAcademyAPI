using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Data.Seed
{
    public class TimeSlotSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<TimeSlot>().HasData(
                new TimeSlot
                {
                    Id = 1,
                    StartTime = new TimeSpan(7,30,0),
                    EndTime = new TimeSpan(8, 45, 0)
                },
                new TimeSlot
                {
                    Id = 2,
                    StartTime = new TimeSpan(11,30,0),
                    EndTime = new TimeSpan(12,45,0)
                }

                );
        }
    }
}
