using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class DayTimeSlotSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<DayTimeSlot>().HasData(
                new DayTimeSlot(1, 2),
                new DayTimeSlot(3, 2),
                new DayTimeSlot(2, 1),
                new DayTimeSlot(4, 1)
            );
        }
    }
}
