using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Models
{
    public class CourseSemester
    {
        [ForeignKey("Course")]
        public String CourseId { get; set; }

        public Course Course { get; set; }

        [ForeignKey("Semester")]
        public int SemesterId { get; set; }

        public Semester Semester { get; set; }
    }
}
