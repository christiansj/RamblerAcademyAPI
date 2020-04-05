using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace RamblerAcademyAPI.Models
{
    public class Subject
    {
        public Subject()
        {

        }

        public Subject(int id, string name, string abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [MaxLength(3)]
        public string Abbreviation { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}
