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
                new Semester(1, 2010, new DateTime(2010, 1, 10), new DateTime(2010, 5, 14), 1),
                new Semester(2, 2010, new DateTime(2010, 5, 20), new DateTime(2010, 8, 12), 2),
                new Semester(3, 2010, new DateTime(2010, 8, 15), new DateTime(2010, 12, 18), 3)
            );
        }
    }
}
