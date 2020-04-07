using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RamblerAcademyAPI.Models
{
    public class TimeSlot
    {
        public TimeSlot() { }

        public TimeSlot(int id, TimeSpan startTime, TimeSpan endTime)
        {
            Id = id;
            StartTime = startTime;
            EndTime = endTime;
        }

        [Key]
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public IEnumerable<DayTimeSlot> DayTimeSlots { get; set; }
    }
}
