using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using RamblerAcademyAPI.Models;
using System;

namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class TimeSlotMutation : ObjectGraphType, IGraphQLMutation
    {
        public TimeSlotMutation(ITimeSlotRepository repository)
        {
            // createTimeSlot(timeSlot)
            Field<TimeSlotType>(
                "createTimeSlot",
                arguments: new QueryArguments(
                   new QueryArgument<NonNullGraphType<TimeSlotInputType>> { Name = "timeSlot" } 
                   //new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "startTime"},
                   //new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "endTime"}

                ),
                resolve: context =>
                {
                    var timeSlot = context.GetArgument<TimeSlot>("timeSlot");
                    return repository.CreateTimeSlot(timeSlot);
                }
            );
            
            // updateTimeSlot(timeSlot, timeSlotId)
            Field<TimeSlotType>(
                "updateTimeSlot",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TimeSlotInputType>> { Name = "timeSlot" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "timeSlotId" }
                ),
                resolve: context =>
                {
                    int timeSlotId = context.GetArgument<int>("timeSlotId");
                    var timeSlot = context.GetArgument<TimeSlot>("timeSlot");

                    var dbTimeSlot = repository.GetTimeSlotById(timeSlotId);
                    if(dbTimeSlot == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find TimeSlot in the db"));
                        return null;
                    }

                    return repository.UpdateTimeSlot(dbTimeSlot, timeSlot);
                }
            );
            
            // deleteTimeSlot(timeSlotId)
            Field<StringGraphType>(
                "deleteTimeSlot",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "timeSlotId" }  
                ),
                resolve: context =>
                {
                    int timeSlotId = context.GetArgument<int>("timeSlotId");

                    var timeSlot = repository.GetTimeSlotById(timeSlotId);
                    if(timeSlot == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find TimeSlot in the db"));
                        return null;
                    }

                    repository.DeleteTimeSlot(timeSlot);
                    return $"The TimeSlot with the id {timeSlotId} was succesfully deleted";
                }
            );
        }
    }
}
