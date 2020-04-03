using System.ComponentModel.DataAnnotations.Schema;

namespace RamblerAcademyAPI.Models
{
    public class CourseSectionTimeSlot
    {
        public CourseSectionTimeSlot(int courseReferenceNumber, int dayId, int timeSlotId)
        {
            CourseReferenceNumber = courseReferenceNumber;
            DayId = dayId;
            TimeSlotId = timeSlotId;
        }

        [ForeignKey("CourseSection")]
        public int CourseReferenceNumber { get; set; }
        public CourseSection CourseSection { get; set; }

        public int DayId { get; set; }
        
        public int TimeSlotId { get; set; }
        public DayTimeSlot DayTimeSlot { get; set; }
    }
}
