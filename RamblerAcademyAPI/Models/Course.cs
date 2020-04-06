using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RamblerAcademyAPI.Models
{
    public class Course
    {
        public Course(int id, int courseNumber, string name, int subjectId)
        {
            Id = id;
            CourseNumber = courseNumber;
            Name = name;
            SubjectId = subjectId;
        }

        private string courseNumberString(int courseNumber)
        {
            string courseNumberString = "";
            if(courseNumber < 100)
            {
                courseNumberString = "0";
            }
            return courseNumberString += courseNumber.ToString();
        }

        [Key]
        public int Id { get; set; }
        public int CourseNumber { get; set; }
        public string Name { get; set; }

        [ForeignKey("Subject")]
        public int SubjectId { get; set; }

        public Subject Subject { get; set; }

        public List<CourseSection> CourseSections { get; set; }
    }
}
