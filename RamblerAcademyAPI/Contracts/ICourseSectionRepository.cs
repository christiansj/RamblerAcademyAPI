using RamblerAcademyAPI.Models;
using System.Collections.Generic;

namespace RamblerAcademyAPI.Contracts
{
    public interface ICourseSectionRepository
    {
        IEnumerable<CourseSection> GetAll();
        CourseSection GetCourseSectionByCrn(int crn);
        CourseSection CreateCourseSection(CourseSection courseSection);
        CourseSection UpdateCourseSection(CourseSection dbCourseSection, CourseSection courseSection);
        void DeleteCourseSection(CourseSection courseSection);
    }
}
