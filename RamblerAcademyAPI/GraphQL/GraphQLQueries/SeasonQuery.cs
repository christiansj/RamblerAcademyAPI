using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class SeasonQuery : ObjectGraphType, IGraphQLQuery
    {
        public SeasonQuery(ISeasonRepository repository)
        {
            // seasons
            Field<ListGraphType<SeasonType>>(
                "seasons",
                resolve: context=> repository.GetAll()
            );

            // season(id)
            Field<SeasonType>(
                "season",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id"}
                ),
                resolve: context=> repository.GetSeasonById(context.GetArgument<int>("id"))
            );
        }
    }
}
