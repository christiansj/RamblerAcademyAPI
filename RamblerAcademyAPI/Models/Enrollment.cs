using System.ComponentModel.DataAnnotations.Schema;

namespace RamblerAcademyAPI.Models
{
    public class Enrollment
    {
        [ForeignKey("CourseSection")]
        public int CourseReferenceNumber { get; set; }
        public CourseSection CourseSection { get; set; }

        [ForeignKey("User")]
        public int StudentId { get; set; }
        public User Student { get; set; }
    }
}
