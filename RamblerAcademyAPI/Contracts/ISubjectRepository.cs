using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Contracts
{
    public interface ISubjectRepository
    {
        IEnumerable<Subject> GetAll();
        Subject GetSubjectById(int id);
        Subject CreateSubject(Subject subject);
        Subject UpdateSubject(Subject dbSubject, Subject subject);
        void DeleteSubject(Subject subject);
    }
}
