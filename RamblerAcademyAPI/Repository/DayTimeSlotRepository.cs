using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RamblerAcademyAPI.Repository
{
    public class DayTimeSlotRepository : IDayTimeSlotRepository
    {
        private readonly RamblerAcademyContext _context;

        public DayTimeSlotRepository(RamblerAcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<DayTimeSlot> GetAll() => _context.DayTimeSlots.ToList();

        public DayTimeSlot GetDayTimeSlotByIds(int dayId, int timeSlotId)
        {
            return _context.DayTimeSlots.FirstOrDefault(dts => dts.DayId == dayId && dts.TimeSlotId == timeSlotId);
        }

        public DayTimeSlot CreateDayTimeSlot(DayTimeSlot dayTimeSlot)
        {
            _context.Add(dayTimeSlot);
            _context.SaveChanges();
            return dayTimeSlot;
        }

        public void DeleteDayTimeSlot(DayTimeSlot dayTimeSlot)
        {
            _context.Remove(dayTimeSlot);
            _context.SaveChanges();
        }
    }
}
