using RamblerAcademyAPI.Models;
using System.Collections.Generic;

namespace RamblerAcademyAPI.Contracts
{
    public interface ICourseSectionDayTimeSlotRepository
    {
        IEnumerable<CourseSectionDayTimeSlot> GetAll();
        IEnumerable<CourseSectionDayTimeSlot> GetAllCourseSectionDayTimeSlotsPerCourseSection(int crn);
        IEnumerable<CourseSectionDayTimeSlot> GetAllCourseSectionDayTimeSlotsPerDay(int dayId);
        CourseSectionDayTimeSlot GetCourseSectionDayTimeSlotByIds(int crn, int dayId, int timeSlotId);
        CourseSectionDayTimeSlot CreateCourseSectionDayTimeSlot(CourseSectionDayTimeSlot courseSectionDayTimeSlot);
        void DeleteCourseSectionDayTimeSlot(CourseSectionDayTimeSlot courseSectionDayTimeSlot);
    }
}
