using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RamblerAcademyAPI.Models
{
    public class CourseSection
    {
        public CourseSection() { }

        public CourseSection(int courseReferenceNumber, int sectionNumber, int courseId, int semesterId, int classroomId)
        {
            CourseReferenceNumber = courseReferenceNumber;
            SectionNumber = sectionNumber;
            CourseId = courseId;
            SemesterId = semesterId;
            ClassroomId = classroomId;
        }

        [Key]
        public int CourseReferenceNumber { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Semester")]
        public int SemesterId { get; set; }
        public Semester Semester { get; set; }

        public int SectionNumber { get; set; }

        [ForeignKey("Classroom")]
        public int ClassroomId { get; set; }
        public Classroom Classroom { get; set; }

        public DateTime FinalExamDate { get; set; }

        public IEnumerable<Enrollment> Enrollments { get; set; }
    }
}
