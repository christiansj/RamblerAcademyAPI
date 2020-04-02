using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Data.Seed
{
    public class CourseSectionTimeSlotSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<CourseSectionTimeSlot>().HasData(
                new CourseSectionTimeSlot
                {
                    CourseReferenceNumber = 57494,
                    DayId = 1,
                    TimeSlotId = 2
                },
                new CourseSectionTimeSlot
                {
                    CourseReferenceNumber = 57494,
                    DayId = 3,
                    TimeSlotId = 2
                },
                 new CourseSectionTimeSlot
                 {
                     CourseReferenceNumber = 59256,
                     DayId = 2,
                     TimeSlotId = 1,
                 },
                  new CourseSectionTimeSlot
                  {
                      CourseReferenceNumber = 59256,
                      DayId = 4,
                      TimeSlotId = 1
                  }
                );
        }
    }
}
