using Microsoft.EntityFrameworkCore;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Data.Seed
{
    public class UserSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<User>().HasData(
                new User(1, "jvs374", "Bill", "Bob", "billBob@example.com", "password", 1),
                new User(2, "cwo479", "Christopher", "Rob", "chrisRob@example.com", "password", 1), 
                new User(3, "mji389", "Matt", "More", "matty@example.com", "password", 1),
                new User(4, "fjo342", "Sally", "Eddy", "sal@example.com", "password", 1)
            );
        }
    }
}
