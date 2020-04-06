using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RamblerAcademyAPI.Repository
{
    public class SemesterRepository : ISemesterRepository
    {
        private readonly RamblerAcademyContext _context;

        public SemesterRepository(RamblerAcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<Semester> GetAll() => _context.Semesters.ToList();

        public Semester GetSemesterById(int id) => _context.Semesters.FirstOrDefault(s => s.Id == id);

        public Semester CreateSemester(Semester semester)
        {
            semester.Id = _context.Semesters.Max(s => s.Id)+1;

            _context.Add(semester);
            _context.SaveChanges();
            return semester;
        }

        public Semester UpdateSemester(Semester dbSemester, Semester semester)
        {
            dbSemester.Year = semester.Year;
            dbSemester.StartDate = semester.StartDate;
            dbSemester.EndDate = semester.EndDate;
            dbSemester.SeasonId = semester.SeasonId;

            _context.SaveChanges();
            return dbSemester;
        }

        public void DeleteSemester(Semester semester)
        {
            _context.Remove(semester);
            _context.SaveChanges();
        }
    }
}
