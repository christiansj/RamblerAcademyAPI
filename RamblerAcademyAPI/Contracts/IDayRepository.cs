using RamblerAcademyAPI.Models;
using System.Collections.Generic;

namespace RamblerAcademyAPI.Contracts
{
    public interface IDayRepository
    {
        IEnumerable<Day> GetAll();
        Day GetDayById(int id);
    }
}
