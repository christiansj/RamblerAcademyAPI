using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;


namespace RamblerAcademyAPI.Repository
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly RamblerAcademyContext _context;

        public EnrollmentRepository(RamblerAcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<Enrollment> GetAll() => _context.Enrollments.ToList();

        public Enrollment GetEnrollmentByIds(long studentId, int courseReferenceNumber)
        {
            return _context.Enrollments.FirstOrDefault(e => e.StudentId == studentId && e.CourseReferenceNumber == courseReferenceNumber);
        }

        public Enrollment CreateEnrollment(Enrollment enrollment)
        {
            _context.Add(enrollment);
            _context.SaveChanges();
            return enrollment;
        }

        public void DeleteEnrollment(Enrollment enrollment)
        {
            _context.Remove(enrollment);
            _context.SaveChanges();
        }
    }
}
