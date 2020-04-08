using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RamblerAcademyAPI.Repository
{
    public class ClassroomRepository : IClassroomRepository
    {
        private readonly RamblerAcademyContext _context;
        public ClassroomRepository(RamblerAcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<Classroom> GetAll() => _context.Classrooms.ToList();

        public IEnumerable<Classroom> GetAllClassroomsPerBuilding(int buildingId)
        {
            return _context.Classrooms
                .Where(c => c.BuildingId == buildingId)
                .ToList();
        }

        public Classroom GetClassroomById(int id) => _context.Classrooms.FirstOrDefault(c=>c.Id == id);

        public Classroom CreateClassroom(Classroom classroom)
        {
            classroom.Id = _context.Classrooms.Max(c => c.Id)+1;
            _context.Add(classroom);
            _context.SaveChanges();

            return classroom;
        }

        public Classroom UpdateClassroom(Classroom dbClassroom, Classroom classroom)
        {
            dbClassroom.Floor = classroom.Floor;
            dbClassroom.HallwayNumber = classroom.HallwayNumber;
            dbClassroom.RoomNumber = classroom.RoomNumber;
            dbClassroom.BuildingId = classroom.BuildingId;

            _context.SaveChanges();
            return dbClassroom;
        }

        public void DeleteClassroom(Classroom classroom)
        {
            _context.Remove(classroom);
            _context.SaveChanges();
        }
    }
}
