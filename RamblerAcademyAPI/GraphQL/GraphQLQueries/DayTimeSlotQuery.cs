using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class DayTimeSlotQuery : ObjectGraphType, IGraphQLQuery
    {
        public DayTimeSlotQuery(IDayTimeSlotRepository repository)
        {
            // dayTimeSlots
            Field<ListGraphType<DayTimeSlotType>>(
                "dayTimeSlots",
                resolve: context=>repository.GetAll()
            );

            // dayTimeSlotsPerDay(dayId)
            Field<ListGraphType<DayTimeSlotType>>(
                "dayTimeSlotsPerDay",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "dayId" }
                ),
                resolve: context =>
                {
                    int dayId = context.GetArgument<int>("dayId");
                    return repository.GetAllDayTimeSlotsPerDay(dayId);
                }
            );

            // dayTimeSlotPerTimeSlot(timeSlotId)
            Field<ListGraphType<DayTimeSlotType>>(
                "dayTimeSlotsPerTimeSlot",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "timeSlotId" }
                ),
                resolve: context =>
                {
                    int timeSlotId = context.GetArgument<int>("timeSlotId");
                    return repository.GetAllDayTimeSlotsPerTimeSlot(timeSlotId);
                }
            );


            // dayTimeSlot(dayId, timeSlotId)
            Field<DayTimeSlotType>(
                "dayTimeSlot",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "dayId"},
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "timeSlotId"}
                ),
                resolve: context =>
                {
                    int dayId = context.GetArgument<int>("dayId");
                    int timeSlotId = context.GetArgument<int>("timeSlotId");
                    return repository.GetDayTimeSlotByIds(dayId, timeSlotId);
                }
            );

       
           
        }
    }
}
