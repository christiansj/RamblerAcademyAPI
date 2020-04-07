using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RamblerAcademyAPI.Models
{
    public class Course
    {
        public Course() { }

        public Course(int id, int courseNumber, string name, int subjectId)
        {
            Id = id;
            CourseNumber = courseNumber;
            Name = name;
            SubjectId = subjectId;
        }


        [Key]
        public int Id { get; set; }
        public int CourseNumber { get; set; }
        public string Name { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }
        public IEnumerable<CourseSection> CourseSections { get; set; }
    }
}
