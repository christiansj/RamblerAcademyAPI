using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RamblerAcademyAPI.Repository
{
    public class CourseSectionDayTimeSlotRepository 
           : ICourseSectionDayTimeSlotRepository
    {
        private readonly RamblerAcademyContext _context;

        public CourseSectionDayTimeSlotRepository(RamblerAcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<CourseSectionDayTimeSlot> GetAll() => _context.CourseSectionDayTimeSlots.ToList();

        public CourseSectionDayTimeSlot GetCourseSectionDayTimeSlotByIds(int crn, int dayId, int timeSlotId)
        {
            return _context.CourseSectionDayTimeSlots.FirstOrDefault(csdt => csdt.CourseReferenceNumber == crn
                                                                    && csdt.DayId == dayId && csdt.TimeSlotId == timeSlotId);
        }

        public CourseSectionDayTimeSlot CreateCourseSectionDayTimeSlot(CourseSectionDayTimeSlot courseSectionDayTimeSlot)
        {
            _context.Add(courseSectionDayTimeSlot);
            _context.SaveChanges();
            return courseSectionDayTimeSlot;
        }

        public void DeleteCourseSectionDayTimeSlot(CourseSectionDayTimeSlot courseSectionDayTimeSlot)
        {
            _context.Remove(courseSectionDayTimeSlot);
            _context.SaveChanges();
        }
    }
}
