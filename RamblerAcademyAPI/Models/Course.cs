using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RamblerAcademyAPI.Models
{
    public class Course
    {
        public Course(string id, string name)
        {
            Id = id;
            Name = name;
        }

        [Key]
        public string Id { get; set; }

        public string Name { get; set; }

        public List<CourseSection> CourseSections { get; set; }
    }
}
