
using System.Collections.Generic;

namespace RamblerAcademyAPI.Models
{
    public class Building
    {
        public Building() { }
        public Building(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public IEnumerable<Classroom> Classrooms { get; set; }
    }
}
