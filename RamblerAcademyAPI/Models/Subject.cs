using System.ComponentModel.DataAnnotations;


namespace RamblerAcademyAPI.Models
{
    public class Subject
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [MaxLength(3)]
        public string Abbreviation { get; set; }
    }
}
