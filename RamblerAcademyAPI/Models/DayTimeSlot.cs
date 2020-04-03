using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RamblerAcademyAPI.Models
{
    public class DayTimeSlot
    {
        public DayTimeSlot(int dayId, int timeSlotId)
        {
            DayId = dayId;
            TimeSlotId = timeSlotId;
        }

        [ForeignKey("Day")]
        public int DayId { get; set; }

        public Day Day { get; set; }

        [ForeignKey("TimeSlot")]
        public int TimeSlotId { get; set; }

        public TimeSlot TimeSlot { get; set; }

        public List<CourseSectionTimeSlot> CourseSectionTimeSlots { get; set; }
    }
}
