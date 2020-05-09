using System.ComponentModel.DataAnnotations;

namespace RamblerAcademyAPI.Models
{
    public class Day
    {
        public Day() { }
        public Day(int id, string name, char abbreviation)
        {
            Id = id;
            Name = name;
            Abbreviation = abbreviation;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public char Abbreviation { get; set; }
    }
}
