using RamblerAcademyAPI.Models;
using System.Collections.Generic;

namespace RamblerAcademyAPI.Contracts
{
    public interface IClassroomRepository
    {
        IEnumerable<Classroom> GetAll();
        Classroom GetClassroomById(int id);
        Classroom CreateClassroom(Classroom classroom);
        Classroom UpdateClassroom(Classroom dbClassroom, Classroom classroom);
        void DeleteClassroom(Classroom classroom);
    }
}
