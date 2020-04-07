using RamblerAcademyAPI.Models;
using System.Collections.Generic;

namespace RamblerAcademyAPI.Contracts
{
    public interface IDayTimeSlotRepository
    {
        IEnumerable<DayTimeSlot> GetAll();
        DayTimeSlot GetDayTimeSlotByIds(int dayId, int timeSlotId);
        DayTimeSlot CreateDayTimeSlot(DayTimeSlot dayTimeSlot);
        void DeleteDayTimeSlot(DayTimeSlot dayTimeSlot);
    }
}
