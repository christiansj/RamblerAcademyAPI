
using System.Collections.Generic;

namespace RamblerAcademyAPI.Models
{
    public class Building
    {
        public Building() { }
        public Building(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public IEnumerable<Classroom> Classrooms { get; set; }
    }
}
