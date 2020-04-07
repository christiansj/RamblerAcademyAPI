using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class DayTimeSlotMutation : ObjectGraphType, IGraphQLMutation
    {
        public DayTimeSlotMutation(IDayTimeSlotRepository repository)
        {
            // createDayTimeSlot(dayId, timeSlotId)
            Field<DayTimeSlotType>(
                "createDayTimeSlot",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<DayTimeSlotInputType>> { Name = "dayTimeSlot"}
                ),
                resolve: context =>
                {
                    var dayTimeSlot = context.GetArgument<DayTimeSlot>("dayTimeSlot");
                    return repository.CreateDayTimeSlot(dayTimeSlot);
                }
            );


            // deleteDayTimeSlot(dayId, timeSlotId)
            Field<StringGraphType>(
               "deleteDayTimeSlot",
               arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "dayId" },
                   new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "timeSlotId" }
               ),
               resolve: context =>
               {
                   int dayId = context.GetArgument<int>("dayId");
                   int timeSlotId = context.GetArgument<int>("timeSlotId");

                   var dayTimeSlot = repository.GetDayTimeSlotByIds(dayId, timeSlotId);
                   if(dayTimeSlot == null)
                   {
                       context.Errors.Add(new ExecutionError("Couldn't find DayTimeSlot in db"));
                       return null;
                   }
                   repository.DeleteDayTimeSlot(dayTimeSlot);
                   return $"The DayTimeSlot with the dayId {dayId} and timeSlotId {timeSlotId} has been successfully deleted";

               }

           );
        }
    }
}
