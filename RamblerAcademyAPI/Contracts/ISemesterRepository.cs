using RamblerAcademyAPI.Models;
using System.Collections.Generic;

namespace RamblerAcademyAPI.Contracts
{
    public interface ISemesterRepository
    {
        IEnumerable<Semester> GetAll();
        IEnumerable<Semester> GetAllSemestersPerSeason(int seasonId);
        Semester GetSemesterById(int id);
        Semester CreateSemester(Semester semester);
        Semester UpdateSemester(Semester dbSemester, Semester semester);
        void DeleteSemester(Semester semester);
    }
}
