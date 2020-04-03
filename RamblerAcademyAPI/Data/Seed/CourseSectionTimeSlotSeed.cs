using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class CourseSectionTimeSlotSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<CourseSectionTimeSlot>().HasData(
                new CourseSectionTimeSlot(57494, 1, 2),
                new CourseSectionTimeSlot(57494, 3, 2),
                new CourseSectionTimeSlot(59256, 2, 1),
                new CourseSectionTimeSlot(59256, 4, 1)
            );
        }
    }
}
