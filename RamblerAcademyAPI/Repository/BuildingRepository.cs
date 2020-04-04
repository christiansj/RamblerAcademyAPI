﻿using RamblerAcademyAPI.Contracts;
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
    }
}
