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
            builder.RemovePluralTableNames();

            builder.Entity<Role>()
                .HasIndex(r => r.Id)
                .IsUnique();

            builder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder.Entity<User>()
                .Property(u => u.AbcId)
                .HasMaxLength(6);

            builder.Entity<User>()
                .HasIndex(u => u.AbcId)
                .IsUnique();

            
            builder.Entity<Subject>()
                .HasIndex(s => s.Abbreviation)
                .IsUnique();

            //builder.Entity<Course>()
               // .HasKey(c => new { c.SubjectId, c.CourseNumber });

            builder.Entity<Enrollment>()
                .HasKey(e => new { e.CourseReferenceNumber, e.StudentId });

            builder.Entity<CourseSection>()
                .HasIndex(cs => new { cs.CourseId, cs.SectionNumber, cs.SemesterId })
                .IsUnique();

            builder.Entity<TimeSlot>()
                .HasIndex(ts => new { ts.StartTime, ts.EndTime })
                .IsUnique();

            builder.Entity<DayTimeSlot>()
                .HasKey(dts => new { dts.DayId, dts.TimeSlotId });

           
            builder.Entity<Classroom>()
                .HasIndex(cs => new { cs.Floor, cs.HallwayNumber, cs.RoomNumber, cs.BuildingId })
                .IsUnique();

            builder.Entity<CourseSectionTimeSlot>()
                .HasKey(csts => new { csts.CourseReferenceNumber, csts.DayId, csts.TimeSlotId });

            builder.Entity<CourseSectionTimeSlot>()
                .HasOne(csts => csts.DayTimeSlot)
                .WithMany(dts => dts.CourseSectionTimeSlots)
                .HasForeignKey(csts => new { csts.DayId, csts.TimeSlotId });
           
            builder.CreateIndexes();
            builder.Seed();
        }

        public DbSet<Building> Buildings { get; set; }
        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseSection> CourseSections { get; set; }
        public DbSet<CourseSectionTimeSlot> CourseSectionTimeSlots { get; set; }
        public DbSet<Day> Days { get; set; }
        public DbSet<DayTimeSlot> DayTimeSlots { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
