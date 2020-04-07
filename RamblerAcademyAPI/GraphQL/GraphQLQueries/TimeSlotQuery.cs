using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class TimeSlotQuery : ObjectGraphType, IGraphQLQuery
    {
        public TimeSlotQuery(ITimeSlotRepository repository)
        {
            // timeSlots
            Field<ListGraphType<TimeSlotType>>(
                "timeSlots",
                resolve: context => repository.GetAll()
            );

            // timeSlot(id)
            Field<TimeSlotType>(
                "timeSlot",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: context =>
                {
                    var timeSlotId = context.GetArgument<int>("id");
                    return repository.GetTimeSlotById(timeSlotId);
                }
            );
        }
    }
}
