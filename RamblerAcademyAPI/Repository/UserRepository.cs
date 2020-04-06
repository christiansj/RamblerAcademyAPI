using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RamblerAcademyAPI.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RamblerAcademyContext _context;

        public UserRepository(RamblerAcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll() => _context.Users.ToList();

        public User GetUserById(int id) => _context.Users.FirstOrDefault(u => u.Id == id);

        public User CreateUser(User user)
        {
            user.Id = _context.Users.Max(u => u.Id) + 1;
            _context.Add(user);
            _context.SaveChanges();

            return user;
        }

        public User UpdateUser(User dbUser, User user)
        {
            dbUser.AbcId = user.AbcId;
            dbUser.Email = user.Email;
            dbUser.FirstName = user.FirstName;
            dbUser.LastName = user.LastName;
            dbUser.Password = user.Password;
            dbUser.RoleId = user.RoleId;

            _context.SaveChanges();
            return dbUser;
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }
    }
}
