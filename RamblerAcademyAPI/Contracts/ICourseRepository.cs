using RamblerAcademyAPI.Models;
using System.Collections.Generic;


namespace RamblerAcademyAPI.Contracts
{
    public interface ICourseRepository
    {
        IEnumerable<Course> GetAll();
        Course GetCourseById(int id);
        Course CreateCourse(Course course);
        Course UpdateCourse(Course dbCourse, Course course);
        void DeleteCourse(Course course);

    }
}
