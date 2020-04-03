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
                new Classroom(1, 1, 1, 12, 1),
                new Classroom(2, 1, 1, 14, 1)
            ) ;
        }
    }
}
