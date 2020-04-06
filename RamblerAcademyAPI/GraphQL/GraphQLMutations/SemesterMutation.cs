using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class SemesterMutation : ObjectGraphType, IGraphQLMutation
    {
        public SemesterMutation(ISemesterRepository repository)
        {
            // createSemester(semester)
            Field<SemesterType>(
                "createSemester",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SemesterInputType>> { Name = "semester" }
                ),
                resolve: context =>
                {
                    var semester = context.GetArgument<Semester>("semester");
                    return repository.CreateSemester(semester);
                }
            );

            // updateSemester(semester, semesterId)
            Field<SemesterType>(
                "updateSemester",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SemesterInputType>> { Name = "semester" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "semesterId" }
                ),
                resolve: context =>
                {
                    int semesterId = context.GetArgument<int>("semesterId");
                    var semester = context.GetArgument<Semester>("semester");

                    var dbSemester = repository.GetSemesterById(semesterId);
                    if (dbSemester == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find semester in db."));
                        return null;
                    }
                    return repository.UpdateSemester(dbSemester, semester);
                }
            );

            // deleteSemester(semester)
            Field<StringGraphType>(
                "deleteSemester",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "semesterId" }
                ),
                resolve: context =>
                {
                    int semesterId = context.GetArgument<int>("semesterId");

                    var semester = repository.GetSemesterById(semesterId);
                    if(semester == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find semester in db"));
                        return null;
                    }

                    repository.DeleteSemester(semester);
                    return $"The semester with the id {semesterId} has been successfully deleted";
                }
            );
        }
    }
}
