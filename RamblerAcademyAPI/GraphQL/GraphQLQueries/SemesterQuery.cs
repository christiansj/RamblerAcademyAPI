using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class SemesterQuery : ObjectGraphType, IGraphQLQuery
    {
        public SemesterQuery(ISemesterRepository repository)
        {
            // semesters
            Field<ListGraphType<SemesterType>>(
                "semesters",
                resolve: context => repository.GetAll()
            );

            // semester(id)
            Field<SemesterType>(
                "semester",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: context => repository.GetSemesterById(context.GetArgument<int>("id"))
            );
        }
    }
}
