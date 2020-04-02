using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RamblerAcademyAPI.Models;
namespace RamblerAcademyAPI.Data
{

    public class RamblerAcademyContext : DbContext
    {
        public RamblerAcademyContext(DbContextOptions<RamblerAcademyContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasIndex(s => s.Email)
                .IsUnique();

            builder.Entity<Course>()
               .HasIndex(c => c.Name)
               .IsUnique();

            builder.Entity<Season>()
                .HasIndex(s => s.Name)
                .IsUnique();

            builder.Entity<CourseSection>()
                .HasIndex(cs => new { cs.CourseId, cs.SectionNumber, cs.SemesterId })
                .IsUnique();


            builder.Entity<Day>()
                .HasIndex(d => d.Name)
                .IsUnique();

            builder.Entity<TimeSlot>()
                .HasIndex(ts => new { ts.StartTime, ts.EndTime })
                .IsUnique();

            builder.Entity<DayTimeSlot>()
                .HasKey(dts => new { dts.DayId, dts.TimeSlotId });

            builder.Entity<Building>()
                .HasIndex(b => b.Name)
                .IsUnique();

            builder.Entity<Classroom>()
                .HasIndex(cs => new { cs.Floor, cs.HallwayNumber, cs.RoomNumber, cs.BuildingId })
                .IsUnique();

            builder.Seed();
        }

       
        public DbSet<User> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Day> Days { get; set; }

    }
}
