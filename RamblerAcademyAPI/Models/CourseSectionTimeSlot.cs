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

    
        public int DayId { get; set; }
        
        public int TimeSlotId { get; set; }
        public DayTimeSlot DayTimeSlot { get; set; }
    }
}
