using System.ComponentModel.DataAnnotations.Schema;

namespace RamblerAcademyAPI.Models
{
    public class Enrollment
    {
        public Enrollment(int courseReferenceNumber, int studentId)
        {
            CourseReferenceNumber = courseReferenceNumber;
            StudentId = studentId;
        }

        [ForeignKey("CourseSection")]
        public int CourseReferenceNumber { get; set; }
        public CourseSection CourseSection { get; set; }

        [ForeignKey("User")]
        public int StudentId { get; set; }
        public User Student { get; set; }
    }
}
