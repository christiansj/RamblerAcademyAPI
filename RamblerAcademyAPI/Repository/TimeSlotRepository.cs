using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RamblerAcademyAPI.Repository
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly RamblerAcademyContext _context;

        public TimeSlotRepository(RamblerAcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<TimeSlot> GetAll() => _context.TimeSlots.ToList();

        public TimeSlot GetTimeSlotById(int id) => _context.TimeSlots.FirstOrDefault(ts => ts.Id == id);

        public TimeSlot CreateTimeSlot(TimeSlot timeSlot)
        {
            timeSlot.Id = _context.TimeSlots.Max(ts => ts.Id) + 1;
            
            _context.Add(timeSlot);
            _context.SaveChanges();

            return timeSlot;
        }

        public TimeSlot UpdateTimeSlot(TimeSlot dbTimeSlot, TimeSlot timeSlot)
        {
            dbTimeSlot.StartTime = timeSlot.StartTime;
            dbTimeSlot.EndTime = timeSlot.EndTime;

            _context.SaveChanges();
            return dbTimeSlot;
        }

        public void DeleteTimeSlot(TimeSlot timeSlot)
        {
            _context.Remove(timeSlot);
            _context.SaveChanges();
        }
    }
}
