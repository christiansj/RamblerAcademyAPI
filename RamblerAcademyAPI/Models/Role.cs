using System.Collections.Generic;

namespace RamblerAcademyAPI.Models
{
    public class Role
    {
        public Role() { }

        public Role(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
