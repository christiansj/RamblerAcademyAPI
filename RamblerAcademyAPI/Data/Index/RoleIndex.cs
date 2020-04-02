using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Data.Index
{
    public class RoleIndex
    {
        public static void Index(ModelBuilder builder)
        {
            builder.Entity<Role>()
                .HasIndex(r => r.Id)
                .IsUnique();
        }
    }
}
