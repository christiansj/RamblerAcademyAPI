using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Repository
{
    public class BuildingRepository : IBuildingRepository
    {
        private readonly RamblerAcademyContext _context;

        public BuildingRepository(RamblerAcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<Building> GetAll() => _context.Buildings.ToList();

        public Building GetBuildingById(int id) => _context.Buildings.FirstOrDefault(b => b.Id == id);

        public Building UpdateBuilding(Building dbBuilding, Building building)
        {
            dbBuilding.Name = building.Name;

            _context.SaveChanges();
            return dbBuilding;
        }

        public Building CreateBuilding(Building building)
        {
            building.Id = _context.Buildings.Max(b => b.Id) + 1;
            _context.Add(building);
            _context.SaveChanges();
            return building;
        }

        public void DeleteBuilding(Building building)
        {
            _context.Remove(building);
            _context.SaveChanges();
        }
    }
}
