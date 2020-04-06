using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class ClassroomMutation : ObjectGraphType, IGraphQLMutation
    {
        public ClassroomMutation(IClassroomRepository repository)
        {
            // createClassroom(classroom)
            Field<ClassroomType>(
                "createClassroom",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ClassroomInputType>> {Name = "classroom" }
                ),
                resolve: context =>
                {
                    var classroom = context.GetArgument<Classroom>("classroom");
                    return repository.CreateClassroom(classroom);
                }
            );

            // updateClassroom(classroom, classroomId)
            Field<ClassroomType>(
                "updateClassroom",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ClassroomInputType>> { Name = "classroom"},
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "classroomId" }
                ),
                resolve: context =>
                {
                    var classroom = context.GetArgument<Classroom>("classroom");
                    int classroomId = context.GetArgument<int>("classroomId");
                   
                    var dbClassroom = repository.GetClassroomById(classroomId);
                    if(dbClassroom == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find classroomm in db"));
                        return null;
                    }

                    return repository.UpdateClassroom(dbClassroom, classroom);
                }
            );

            // deleteClassroom(classroomId)
            Field<StringGraphType>(
                "deleteClassroom",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "classroomId"}
                ),
                resolve: context =>
                {
                    int classroomId = context.GetArgument<int>("classroomId");
                    var classroom = repository.GetClassroomById(classroomId);

                    if(classroom == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find classroom in db"));
                        return null;
                    }

                    repository.DeleteClassroom(classroom);
                    return $"The classroom with id {classroomId} has been successfully deleted";
                }
            );
        }
    }
}
