using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class DayTimeSlotSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<DayTimeSlot>().HasData(
                new DayTimeSlot
                {
                    DayId = 1,
                    TimeSlotId = 2
                },
                new DayTimeSlot
                {
                    DayId = 3,
                    TimeSlotId = 2
                },
                new DayTimeSlot
                {
                    DayId = 2,
                    TimeSlotId = 1
                },
                new DayTimeSlot
                {
                    DayId = 4,
                    TimeSlotId = 1
                }
                );
        }
    }
}
