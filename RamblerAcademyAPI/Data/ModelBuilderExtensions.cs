using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RamblerAcademyAPI.Data.Seed;
using RamblerAcademyAPI.Data.Index;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RamblerAcademyAPI.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder builder)
        {
            RoleSeed.Seed(builder);
            UserSeed.Seed(builder);
            //User Seed

            SeasonSeed.Seed(builder);
            SemesterSeed.Seed(builder);
            SubjectSeed.Seed(builder);
            CourseSeed.Seed(builder);
            
            DaySeed.Seed(builder);
            TimeSlotSeed.Seed(builder);
            DayTimeSlotSeed.Seed(builder);

            BuildingSeed.Seed(builder);
            ClassroomSeed.Seed(builder);

            CourseSectionSeed.Seed(builder);
            CourseSectionTimeSlotSeed.Seed(builder);

            EnrollmentSeed.Seed(builder);
        }

        public static void CreateIndexes(this ModelBuilder builder)
        {
            IndexUtil.CreateUniqueNameIndexes(builder);
        }
        public static void RemovePluralTableNames(this ModelBuilder builder)
        {
            foreach(IMutableEntityType entity in builder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }
        }
    }
}
