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
                new TimeSlot(2, new TimeSpan(9, 0, 0), new TimeSpan(10, 15, 0)),
                new TimeSlot(3, new TimeSpan(11,30,0), new TimeSpan(12,45,0)),
                new TimeSlot(4, new TimeSpan(13, 0, 0), new TimeSpan(14, 15, 0)),
                new TimeSlot(5, new TimeSpan(14, 30, 0), new TimeSpan(15, 45, 0)),
                new TimeSlot(6, new TimeSpan(16, 0, 0), new TimeSpan(17, 15, 0)),
                new TimeSlot(7, new TimeSpan(17, 30, 0), new TimeSpan(18, 45, 0)),
                new TimeSlot(8, new TimeSpan(19, 0, 0), new TimeSpan(20, 15, 0)),

                new TimeSlot(9, new TimeSpan(9, 0, 0), new TimeSpan(9, 50, 0)),
                new TimeSlot(10, new TimeSpan(10, 0, 0), new TimeSpan(10, 50, 0)),
                new TimeSlot(11, new TimeSpan(11, 0, 0), new TimeSpan(11, 50, 0)),
                new TimeSlot(12, new TimeSpan(12, 0, 0), new TimeSpan(12, 50, 0)),
                new TimeSlot(13, new TimeSpan(13, 0, 0), new TimeSpan(13, 50, 0)),
                new TimeSlot(14, new TimeSpan(14, 0, 0), new TimeSpan(14, 50, 0)),
                new TimeSlot(15, new TimeSpan(15, 0, 0), new TimeSpan(15, 50, 0)),
                new TimeSlot(16, new TimeSpan(16, 0, 0), new TimeSpan(16, 50, 0)),
                new TimeSlot(17, new TimeSpan(17, 0, 0), new TimeSpan(17, 50, 0))
            );
        }
    }
}
