using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class EnrollmentQuery : ObjectGraphType, IGraphQLQuery
    {
        public EnrollmentQuery(IEnrollmentRepository repository)
        {
            // enrollments
            Field<ListGraphType<EnrollmentType>>(
                "enrollments",
                resolve: context=>repository.GetAll()
            );

            // enrollmentsPerStudent(studentId)
            Field<ListGraphType<EnrollmentType>>(
                "enrollmentsPerStudent",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "studentId" }
                ),
                resolve: context =>
                {
                    long studentId = context.GetArgument<long>("studentId");
                    return repository.GetAllEnrollmentsPerUser(studentId);
                }
            );

            // enrollmentsPerCourseSection(crn)
            Field<ListGraphType<EnrollmentType>>(
                "enrollmentsPerCourseSection",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "crn" }
                ),
                resolve: context =>
                {
                    int crn = context.GetArgument<int>("crn");
                    return repository.GetAllEnrollmentsPerCourseSection(crn);
                }
            );

            // enrollment(studentId, crn)
            Field<EnrollmentType>(
                "enrollment",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "studentId" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "crn" }
                ),
                resolve: context =>
                {
                    long studentId = context.GetArgument<long>("studentId");
                    int crn = context.GetArgument<int>("crn");
                    return repository.GetEnrollmentByIds(studentId, crn);
                }
            );

           
        }
    }
}
