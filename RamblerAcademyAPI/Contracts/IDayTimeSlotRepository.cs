using RamblerAcademyAPI.Models;
using System.Collections.Generic;

namespace RamblerAcademyAPI.Contracts
{
    public interface IDayTimeSlotRepository
    {
        IEnumerable<DayTimeSlot> GetAll();
        IEnumerable<DayTimeSlot> GetAllDayTimeSlotsPerDay(int dayId);
        IEnumerable<DayTimeSlot> GetAllDayTimeSlotsPerTimeSlot(int timeSlotId);
        DayTimeSlot GetDayTimeSlotByIds(int dayId, int timeSlotId);
        DayTimeSlot CreateDayTimeSlot(DayTimeSlot dayTimeSlot);
        void DeleteDayTimeSlot(DayTimeSlot dayTimeSlot);
    }
}
