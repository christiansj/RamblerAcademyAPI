using RamblerAcademyAPI.Models;
using System.Collections.Generic;


namespace RamblerAcademyAPI.Contracts
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
        Role GetRoleById(int id);
        Role CreateRole(Role role);
        Role UpdateRole(Role dbRole, Role role);
        void DeleteRole(Role role);
    }
}
