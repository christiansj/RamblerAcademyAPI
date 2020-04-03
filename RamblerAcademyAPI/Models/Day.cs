using System.ComponentModel.DataAnnotations;

namespace RamblerAcademyAPI.Models
{
    public class Day
    {
        public Day(int id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
