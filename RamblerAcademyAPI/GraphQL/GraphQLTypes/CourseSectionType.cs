using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class CourseSectionType : ObjectGraphType<CourseSection>
    {
        public CourseSectionType(ICourseRepository courseRepository, ISemesterRepository semesterRepository, IClassroomRepository classroomRepository, IEnrollmentRepository enrollmentRepository)
        {
            Field(cs => cs.CourseReferenceNumber, type: typeof(IdGraphType))
                .Name("crn")
                .Description("The CourseReferenceNumber (CRN) property of the CourseSection. Primary Key");

            Field(cs => cs.SectionNumber, type: typeof(IntGraphType))
                .Description("The SectionNumber property of the CourseSection. Part of composite Unique Index of: CourseId, SectionNumber, and SemesterId");

            Field(cs => cs.CourseId, type: typeof(IntGraphType))
                .Description("The CourseId property of the CourseSection. References the Id property of a Course object. Part of composite Unique Index of: CourseId, SectionNumber, and SemesterId");

            Field<CourseType>(
                "course",
                resolve: context=> courseRepository.GetCourseById(context.Source.CourseId)
            );

            Field(cs => cs.SemesterId, type: typeof(IntGraphType))
                 .Description("The SemesterId property of the CourseSection. References the Id property of a Semester object. Part of composite Unique Index of: CourseId, SectionNumber, and SemesterId");

            Field<SemesterType>(
                "semester",
                resolve: context => semesterRepository.GetSemesterById(context.Source.SemesterId)
            );

            Field(cs => cs.ClassroomId, type: typeof(IntGraphType))
                .Description("The ClassroomId property of the CourseSection. References the Id property of a Classroom object. Part of composite Unique Index of: CourseId, SectionNumber, and SemesterId");

            Field<ClassroomType>(
                "classroom",
                resolve: context => classroomRepository.GetClassroomById(context.Source.ClassroomId)
            );

            Field<ListGraphType<EnrollmentType>>(
                "enrollments",
                resolve: context => enrollmentRepository.GetAllEnrollmentsPerCourseSection(context.Source.CourseReferenceNumber)
            );
        }
    }
}
