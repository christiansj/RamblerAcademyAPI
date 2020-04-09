using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using RamblerAcademyAPI.GraphQL.GraphQLUserErrors;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class EnrollmentMutation : ObjectGraphType, IGraphQLMutation
    {
        public EnrollmentMutation(IEnrollmentRepository repository)
        {
            // CreateEnrollment(enrollment)
            Field<EnrollmentType>(
                "createEnrollment",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<EnrollmentInputType>> { Name = "enrollment" }
                ),
                resolve: context =>
                {
                    var enrollment = context.GetArgument<Enrollment>("enrollment");
                    return repository.CreateEnrollment(enrollment);
                }
            );

            // DeleteEnrollment(studentId, crn)
            Field<StringGraphType>(
                "deleteEnrollment",
                arguments: new QueryArguments(
                     new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "studentId" },
                     new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "crn" }
                ),
                resolve: context =>
                {
                    long studentId = context.GetArgument<long>("studentId");
                    int crn = context.GetArgument<int>("crn");

                    var enrollment = repository.GetEnrollmentByIds(studentId, crn);
                    if(enrollment == null)
                    {
                        context.Errors.Add(NotFoundError());
                        return null;
                    }

                    repository.DeleteEnrollment(enrollment);
                    return $"The Enrollment with the studentId {studentId} and courseReferenceNumber {crn} has been successfully deleted";
                }
            );
        }

        private ExecutionError NotFoundError()
        {
            return new ExecutionError(GraphQLUserError.NotFoundString("Enrollment"));
        }
    }
}
