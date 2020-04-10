using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly RamblerAcademyContext _context;
        public SubjectRepository(RamblerAcademyContext context)
        {
            _context = context;
        }
        public IEnumerable<Subject> GetAll() => _context.Subjects.ToList();

        public Subject GetSubjectById(int id) => _context.Subjects.FirstOrDefault(s => s.Id == id);

        public Subject CreateSubject(Subject subject)
        {
            subject.Id = _context.Subjects.Max(s => s.Id) + 1;
            _context.Add(subject);
            _context.SaveChanges();

            return subject;
        }

        public Subject UpdateSubject(Subject dbSubject, Subject subject)
        {
            dbSubject.Name = subject.Name;
            dbSubject.Abbreviation = subject.Abbreviation;
            
            _context.SaveChangesAsync();
            return dbSubject;
        }

        public void DeleteSubject(Subject subject)
        {
            _context.Remove(subject);
            _context.SaveChanges();
        }
    }
}
