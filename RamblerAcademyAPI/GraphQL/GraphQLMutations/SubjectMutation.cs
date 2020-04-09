using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using RamblerAcademyAPI.GraphQL.GraphQLUserErrors;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class SubjectMutation : ObjectGraphType, IGraphQLMutation
    {
        public SubjectMutation(ISubjectRepository repository)
        {
            // createSubject(subject)
            Field<SubjectType>(
                "createSubject",
                arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<SubjectInputType>> { Name = "subject" }
                    ),
                resolve: context =>
                {
                    var subject = context.GetArgument<Subject>("subject");
                    return repository.CreateSubject(subject);
                }
            );

            // updateSubject(subject, subjectId)
            Field<SubjectType>(
                "updateSubject",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SubjectInputType>> { Name = "subject"},
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name= "subjectId"}
                ),
                resolve: context =>
                {
                    var subject = context.GetArgument<Subject>("subject");
                    var subjectId = context.GetArgument<int>("subjectId");

                    var dbSubject = repository.GetSubjectById(subjectId);
                    if(dbSubject == null)
                    {
                        context.Errors.Add(NotFoundError());
                        return null;
                    }
                    return repository.UpdateSubject(dbSubject, subject);
                }

            );

            // deleteSubject(subjectId)
            Field<StringGraphType>(
                "deleteSubject",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "subjectId"}
                ),
                resolve: context =>
                {
                    int subjectId = context.GetArgument<int>("subjectId");
                    var subject = repository.GetSubjectById(subjectId);
                    if(subject == null)
                    {
                        context.Errors.Add(NotFoundError());
                        return null;
                    }
                    repository.DeleteSubject(subject);
                    return $"Subject with id {subjectId} was succesfully deleted";
                }
            );
        }

        private ExecutionError NotFoundError()
        {
            return new ExecutionError(GraphQLUserError.NotFoundString("Subject"));
        }
    }
}
