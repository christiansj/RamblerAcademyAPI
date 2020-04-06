using RamblerAcademyAPI.Models;
using System.Collections.Generic;

namespace RamblerAcademyAPI.Contracts
{
    public interface ISeasonRepository
    {
        IEnumerable<Season> GetAll();
        Season GetSeasonById(int id);
        Season CreateSeason(Season season);
        Season UpdateSeason(Season dbSeason, Season season);
        void DeleteSeason(Season season);
    }
}
