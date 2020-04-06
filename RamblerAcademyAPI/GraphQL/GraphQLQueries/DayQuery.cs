using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class DayQuery : ObjectGraphType, IGraphQLQuery
    {
        public DayQuery(IDayRepository repository) 
        {
            // days
            Field<ListGraphType<DayType>>(
                "days",
                resolve: context => repository.GetAll()
            );

            // day(id)
            Field<DayType>(
                "day",
                arguments: new QueryArguments(
                    new QueryArgument<IdGraphType> { Name = "id" }
                ),
                resolve: context =>
                {
                    int dayId = context.GetArgument<int>("id");
                    return repository.GetDayById(dayId);
                }
            );
        }
    }
}
