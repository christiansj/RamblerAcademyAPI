using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RamblerAcademyAPI.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly RamblerAcademyContext _context;

        public RoleRepository(RamblerAcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<Role> GetAll() => _context.Roles.ToList();

        public Role GetRoleById(int id) => _context.Roles.FirstOrDefault(r => r.Id == id);

        public Role CreateRole(Role role)
        {
            role.Id = _context.Roles.Max(r => r.Id) + 1;
            _context.Add(role);
            _context.SaveChanges();

            return role;
        }

        public Role UpdateRole(Role dbRole, Role role)
        {
            dbRole.Name = role.Name;

            _context.SaveChanges();
            return dbRole;
        }

        public void DeleteRole(Role role)
        {
            _context.Remove(role);
            _context.SaveChanges();
        }
    }
}
