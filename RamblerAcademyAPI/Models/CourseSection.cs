using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Models
{
    public class CourseSection
    {
        [Key]
        public int CourseReferenceNumber { get; set; }

        [ForeignKey("Course")]
        public String CourseId { get; set; }

        [ForeignKey("Semester")]
        public int SemesterId { get; set; }

        public int SectionNumber { get; set; }

        [ForeignKey("Classroom")]
        public int ClassroomId { get; set; }

        public DateTime FinalExamDate { get; set; }
    }
}
