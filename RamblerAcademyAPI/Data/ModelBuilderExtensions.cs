using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RamblerAcademyAPI.Data.Seed;
using RamblerAcademyAPI.Data.Index;
namespace RamblerAcademyAPI.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            SeedSeasons(builder);
            SeedSemesters(builder);
            SeedCourses(builder);
            
            DaySeed.Seed(builder);
            TimeSlotSeed.Seed(builder);
            DayTimeSlotSeed.Seed(builder);
            BuildingSeed.Seed(builder);
            ClassroomSeed.Seed(builder);
            CourseSectionSeed.Seed(builder);
            CourseSectionTimeSlotSeed.Seed(builder);
            RoleSeed.Seed(builder);
        }

        public static void CreateIndexes(this ModelBuilder builder)
        {
            RoleIndex.Index(builder);
        }

        private static void SeedSeasons(ModelBuilder builder)
        {
            builder.Entity<Season>().HasData(
                new Season
                {
                    Id = 1,
                    Name = "Spring"
                },
                new Season
                {
                    Id = 2,
                    Name = "Summer"
                },
                new Season
                {
                    Id = 3,
                    Name = "Fall"
                }
            );
        }

        private static void SeedSemesters(ModelBuilder builder)
        {
            builder.Entity<Semester>().HasData(
                new Semester
                {
                    Id = 1,
                    SeasonId = 1,
                    Year = 2010,
                    StartDate = new DateTime(2010, 1, 10),
                    EndDate = new DateTime(2010, 5, 14)
                },
                new Semester
                {
                    Id = 2,
                    SeasonId = 2,
                    Year = 2010,
                    StartDate = new DateTime(2010, 5, 20),
                    EndDate = new DateTime(2010, 8, 12)
                },
                new Semester
                {
                    Id = 3,
                    SeasonId = 3,
                    Year = 2010,
                    StartDate = new DateTime(2010, 8, 15),
                    EndDate = new DateTime(2010, 12, 18)
                }
             );
        }

        private static void SeedCourses(ModelBuilder builder)
        {
            builder.Entity<Course>().HasData(
                new Course
                {
                    Id = "MAT010",
                    Name = "College Algebra"
                },
                new Course
                {
                    Id = "MAT100",
                    Name = "Pre-Calculus"
                },
                new Course
                {
                    Id = "MAT400",
                    Name = "Calculus I"
                },
                new Course
                {
                    Id = "MAT250",
                    Name = "Summer Math Camp"
                }
                );
        }
    }
}
