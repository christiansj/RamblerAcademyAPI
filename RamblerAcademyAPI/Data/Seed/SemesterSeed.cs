using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;
using System;

namespace RamblerAcademyAPI.Data.Seed
{
    public class SemesterSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Semester>().HasData(
                NewSemester(1, 1, 2010, new DateTime(2010, 1, 10), new DateTime(2010, 5, 14)),
                NewSemester(2, 2, 2010, new DateTime(2010, 5, 20), new DateTime(2010, 8, 12)),
                NewSemester(3, 3, 2010, new DateTime(2010, 8, 15), new DateTime(2010, 12, 18))
            );
        }
        private static Semester NewSemester(int Id, int SeasonId, int Year, DateTime StartDate, DateTime EndDate)
        {
            return new Semester
            {
                Id = Id,
                SeasonId = SeasonId,
                Year = Year,
                StartDate = StartDate,
                EndDate = EndDate
            };
        }
    }
}
