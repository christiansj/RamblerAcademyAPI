using RamblerAcademyAPI.Models;
using System.Collections.Generic;

namespace RamblerAcademyAPI.Contracts
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        User GetUserById(long id);
        User CreateUser(User user);
        User UpdateUser(User dbUser, User user);
        void DeleteUser(User user);
    }
}
