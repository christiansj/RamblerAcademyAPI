using RamblerAcademyAPI.Models;
using System.Collections.Generic;

namespace RamblerAcademyAPI.Contracts
{
    public interface ITimeSlotRepository
    {
        IEnumerable<TimeSlot> GetAll();
        TimeSlot GetTimeSlotById(int id);
        TimeSlot CreateTimeSlot(TimeSlot timeSlot);
        TimeSlot UpdateTimeSlot(TimeSlot dbTimeSlot, TimeSlot timeSlot);
        void DeleteTimeSlot(TimeSlot timeSlot);
    }
}
