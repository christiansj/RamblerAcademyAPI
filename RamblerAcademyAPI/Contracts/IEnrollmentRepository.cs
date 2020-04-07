using RamblerAcademyAPI.Models;
using System.Collections.Generic;

namespace RamblerAcademyAPI.Contracts
{
    public interface IEnrollmentRepository
    {
        IEnumerable<Enrollment> GetAll();
        Enrollment GetEnrollmentByIds(long studentId, int courseRefrenceNumber);
        Enrollment CreateEnrollment(Enrollment enrollment);
       
        void DeleteEnrollment(Enrollment enrollment);
    }
}
