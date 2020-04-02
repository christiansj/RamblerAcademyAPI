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
                new Classroom
                {
                    Id = 1,
                    Floor = 1,
                    HallwayNumber = 1,
                    RoomNumber = 12,
                    BuildingId = 1
                },
                new Classroom
                {
                    Id = 2,
                    Floor = 1,
                    HallwayNumber = 1,
                    RoomNumber = 14,
                    BuildingId = 1
                }
                );
        }
    }
}
