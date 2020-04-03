using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;
using System;

namespace RamblerAcademyAPI.Data.Seed
{
    public class TimeSlotSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<TimeSlot>().HasData(
                new TimeSlot(1, new TimeSpan(7,30,0), new TimeSpan(8, 45, 0)),
                new TimeSlot(2, new TimeSpan(11,30,0), new TimeSpan(12,45,0))
            );
        }
    }
}
