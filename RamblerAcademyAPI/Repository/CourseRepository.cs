using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RamblerAcademyAPI.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly RamblerAcademyContext _context;
        public CourseRepository(RamblerAcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<Course> GetAll() => _context.Courses.ToList();

        public Course GetCourseById(int id) => _context.Courses.FirstOrDefault(c=>c.Id==id);

        public Course CreateCourse(Course course)
        {
            course.Id = _context.Courses.Max(c => c.Id) + 1;
            _context.Add(course);
            _context.SaveChanges();
            return course;
        }

        public Course UpdateCourse(Course dbCourse, Course course)
        {
            dbCourse.Name = course.Name;
            dbCourse.SubjectId = course.SubjectId;
            dbCourse.CourseNumber = course.CourseNumber;

            _context.SaveChanges();
            return dbCourse;
        }

        public void DeleteCourse(Course course)
        {
            _context.Remove(course);
            _context.SaveChanges();
        }
    }
}
