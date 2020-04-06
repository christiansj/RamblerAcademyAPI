using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RamblerAcademyAPI.Repository
{
    public class SeasonRepository : ISeasonRepository
    {
        private readonly RamblerAcademyContext _context;
        public SeasonRepository(RamblerAcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<Season> GetAll() => _context.Seasons.ToList();

        public Season GetSeasonById(int id) => _context.Seasons.FirstOrDefault(s=>s.Id==id);

        public Season CreateSeason(Season season)
        {
            season.Id = _context.Seasons.Max(s => s.Id) + 1;
            _context.Add(season);
            _context.SaveChanges();

            return season;
        }

        public Season UpdateSeason(Season dbSeason, Season season)
        {
            dbSeason.Name = season.Name;

            _context.SaveChanges();
            return dbSeason;
        }

        public void DeleteSeason(Season season)
        {
            _context.Remove(season);
            _context.SaveChanges();
        }
    }
}
