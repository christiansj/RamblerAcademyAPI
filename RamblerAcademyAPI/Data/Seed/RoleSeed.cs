using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Data.Seed
{
    public class RoleSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role
                {
                    Id = 1,
                    Name = "Normal"
                },
                new Role
                {
                    Id = 2,
                    Name = "Admin"
                },
                new Role
                {
                    Id = 3,
                    Name = "Super Admin"
                }
                );
        }
    }
}
