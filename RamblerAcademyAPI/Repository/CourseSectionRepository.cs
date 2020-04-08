using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace RamblerAcademyAPI.Repository
{
    public class CourseSectionRepository : ICourseSectionRepository
    {
        private readonly RamblerAcademyContext _context;
        public CourseSectionRepository(RamblerAcademyContext context)
        {
            _context = context;
        }

        public IEnumerable<CourseSection> GetAll() => _context.CourseSections.ToList();

        public IEnumerable<CourseSection> GetAllCourseSectionsPerCourse(int courseId)
        {
            return _context.CourseSections
                .Where(cs => cs.CourseId == courseId)
                .ToList();
        }

        public IEnumerable<CourseSection> GetAllCourseSectionsPerClassroom(int classroomId)
        {
            return _context.CourseSections
                .Where(cs => cs.ClassroomId == classroomId)
                .ToList();
        }

        public CourseSection GetCourseSectionByCrn(int crn) => _context.CourseSections.FirstOrDefault(cs => cs.CourseReferenceNumber == crn);

        public CourseSection CreateCourseSection(CourseSection courseSection)
        {
            _context.Add(courseSection);
            _context.SaveChanges();

            return courseSection;
        }

        public CourseSection UpdateCourseSection(CourseSection dbCourseSection, CourseSection courseSection)
        {
            dbCourseSection.CourseId = courseSection.CourseId;
            dbCourseSection.ClassroomId = courseSection.ClassroomId;
            dbCourseSection.SemesterId = courseSection.SemesterId;
            dbCourseSection.FinalExamDate = courseSection.FinalExamDate;

            _context.SaveChanges();
            return dbCourseSection;
        }

        public void DeleteCourseSection(CourseSection courseSection)
        {
            _context.Remove(courseSection);
            _context.SaveChanges();
        }
    }
}
