using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class DayTimeSlotSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            
            builder.Entity<DayTimeSlot>().HasData(
                // Tuesday, 7:30-20:15, 1 hr 15 min
                new DayTimeSlot(3, 1),
                new DayTimeSlot(3, 2),
                new DayTimeSlot(3, 3),
                new DayTimeSlot(3, 4),
                new DayTimeSlot(3, 5),
                new DayTimeSlot(3, 6),
                new DayTimeSlot(3, 7),
                new DayTimeSlot(3, 8),

                // Thursday, 7:30-20:15, 1 hr 15 min
                new DayTimeSlot(5, 1),
                new DayTimeSlot(5, 2),
                new DayTimeSlot(5, 3),
                new DayTimeSlot(5, 4),
                new DayTimeSlot(5, 5),
                new DayTimeSlot(5, 6),
                new DayTimeSlot(5, 7),
                new DayTimeSlot(5, 8),

                // Monday, 9:00-17:00, 50 min 
                new DayTimeSlot(2, 9),
                new DayTimeSlot(2, 10),
                new DayTimeSlot(2, 11),
                new DayTimeSlot(2, 12),
                new DayTimeSlot(2, 13),
                new DayTimeSlot(2, 14),
                new DayTimeSlot(2, 15),
                new DayTimeSlot(2, 16),
                new DayTimeSlot(2, 17),

                // Wednesday, 9:00-17:00, 50 min 
                new DayTimeSlot(4, 9),
                new DayTimeSlot(4, 10),
                new DayTimeSlot(4, 11),
                new DayTimeSlot(4, 12),
                new DayTimeSlot(4, 13),
                new DayTimeSlot(4, 14),
                new DayTimeSlot(4, 15),
                new DayTimeSlot(4, 16),
                new DayTimeSlot(4, 17),

                // Friday, 9:00-17:00, 50 min 
                new DayTimeSlot(6, 9),
                new DayTimeSlot(6, 10),
                new DayTimeSlot(6, 11),
                new DayTimeSlot(6, 12),
                new DayTimeSlot(6, 13),
                new DayTimeSlot(6, 14),
                new DayTimeSlot(6, 15),
                new DayTimeSlot(6, 16),
                new DayTimeSlot(6, 17)
            );
        }
    }
}
