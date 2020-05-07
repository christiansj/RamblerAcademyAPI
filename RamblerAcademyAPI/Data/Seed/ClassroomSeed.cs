using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Data.Seed
{
    public class ClassroomSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Classroom>().HasData(
                // Main Building
                new Classroom(1, 1, 1, 12, 30, 1),
                new Classroom(2, 1, 1, 14, 30, 1),

                // Rodney Sciences Building
                new Classroom(3, 1, 1, 10, 200, 4),
                new Classroom(4, 1, 1, 20, 200, 4),
                new Classroom(5, 1, 2, 32, 30, 4),
                new Classroom(6, 1, 2, 43, 30, 4),

                // Welch Humanities
                new Classroom(7, 1, 1, 2, 50, 2),
                new Classroom(8, 1, 1, 7, 50, 2)
            ) ;
        }
    }
}
