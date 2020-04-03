using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class CourseSectionTimeSlotSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<CourseSectionTimeSlot>().HasData(
                new CourseSectionTimeSlot(57494, 3, 2),
                new CourseSectionTimeSlot(57494, 5, 2),

                new CourseSectionTimeSlot(59256, 3, 3),
                new CourseSectionTimeSlot(59256, 5, 3),

                new CourseSectionTimeSlot(78934, 3, 5),
                new CourseSectionTimeSlot(78934, 5, 5),

                new CourseSectionTimeSlot(94583, 3, 6),
                new CourseSectionTimeSlot(94583, 5, 6)
            );
        }
    }
}
