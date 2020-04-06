using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RamblerAcademyAPI.Repository
{
    public class DayRepository : IDayRepository
    {
        private readonly RamblerAcademyContext _context;
        public DayRepository(RamblerAcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<Day> GetAll() => _context.Days.ToList();

        public Day GetDayById(int id) => _context.Days.FirstOrDefault(d => d.Id == id);
    }
}
