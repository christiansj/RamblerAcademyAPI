using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RamblerAcademyAPI.Models
{
    public class Course
    {
        public Course(string subjectAbbreviation, int courseNumber, string name)
        {
            

            Id = subjectAbbreviation+courseNumberString(courseNumber);
            Name = name;
            CourseNumber = courseNumber;
            SubjectAbbreviation = subjectAbbreviation;
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
        public string Id { get; set; }
        public int CourseNumber { get; set; }
        public string Name { get; set; }

      
        public string SubjectAbbreviation { get; set; }
        public Subject Subject { get; set; }

        public List<CourseSection> CourseSections { get; set; }
    }
}
