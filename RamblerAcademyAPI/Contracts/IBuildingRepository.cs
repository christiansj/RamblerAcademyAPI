using RamblerAcademyAPI.Models;
using System.Collections.Generic;

namespace RamblerAcademyAPI.Contracts
{
    public interface IBuildingRepository
    {
        IEnumerable<Building> GetAll();
    }
}
