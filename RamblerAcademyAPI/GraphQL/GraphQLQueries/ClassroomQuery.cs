using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class ClassroomQuery : ObjectGraphType, IGraphQLQuery
    {
        public ClassroomQuery(IClassroomRepository repository)
        {
            Field<ListGraphType<ClassroomType>>(
                "classrooms",
                resolve: context => repository.GetAll()
            );

            Field<ClassroomType>(
                "classroom",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: context => repository.GetClassroomById(context.GetArgument<int>("id"))
            ) ;
        }
    }
}
