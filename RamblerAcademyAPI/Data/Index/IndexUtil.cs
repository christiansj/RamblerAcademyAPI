using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Index
{
    public class IndexUtil
    {
        public static void CreateUniqueNameIndexes(ModelBuilder builder)
        {
            builder.Entity<Role>()
                .HasIndex(r => r.Id)
                .IsUnique();

            builder.Entity<Course>()
               .HasIndex(c => c.Name)
               .IsUnique();

            builder.Entity<Season>()
             .HasIndex(s => s.Name)
             .IsUnique();

            builder.Entity<Day>()
                .HasIndex(d => d.Name)
                .IsUnique();

            builder.Entity<Building>()
               .HasIndex(b => b.Name)
               .IsUnique();
        }
    }
}
