using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Models
{
    public class CourseSectionTimeSlot
    {
        [ForeignKey("CourseSection")]
        public int CourseReferenceNumber { get; set; }
        public CourseSection CourseSection { get; set; }

        [ForeignKey("DayTimeSlot_Day"), Column("DayId")]
        public int DayId { get; set; }
        

        [ForeignKey("DayTimeSlot_TimeSlot"), Column("TimeSlotId")]
        public int TimeSlotId { get; set; }
        public DayTimeSlot DayTimeSlot { get; set; }
    }
}
