using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class RoleSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role(1, "Normal"),
                new Role(2, "Admin"),
                new Role(3, "Super Admin")
            );
        }
    }
}
