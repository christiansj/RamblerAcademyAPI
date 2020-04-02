using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Models
{
    public class DayTimeSlot
    {
        [ForeignKey("Day")]
        public int DayId { get; set; }

        public Day Day { get; set; }

        [ForeignKey("TimeSlot")]
        public int TimeSlotId { get; set; }

        public TimeSlot TimeSlot { get; set; }

        public List<CourseSectionTimeSlot> CourseSectionTimeSlots { get; set; }
    }
}
