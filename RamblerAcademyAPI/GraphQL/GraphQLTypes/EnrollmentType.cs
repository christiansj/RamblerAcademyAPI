using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class EnrollmentType : ObjectGraphType<Enrollment>
    {
        public EnrollmentType(IUserRepository userRepository, ICourseSectionRepository courseSectionRepository)
        {
            Field(e => e.StudentId, type: typeof(IdGraphType))
                .Description("StudentId property of the Enrollment object. References Id property of a User object. Part of primary composite key: StudentId and CourseReferenceNumber");

            Field<UserType>(
                "student",
                resolve: context=>userRepository.GetUserById(context.Source.StudentId)
            );

            Field(e => e.CourseReferenceNumber, type: typeof(IdGraphType))
                .Description("CourseReferenceNumber property of the Enrollment object. References Id property of a User object. Part of primary composite key: StudentId and CourseReferenceNumber");

            Field<CourseSectionType>(
                "courseSection",
                resolve: context => courseSectionRepository.GetCourseSectionByCrn(context.Source.CourseReferenceNumber)
            );
        }
    }
}
