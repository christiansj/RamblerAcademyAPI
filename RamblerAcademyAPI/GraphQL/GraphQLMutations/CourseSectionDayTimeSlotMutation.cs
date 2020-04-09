using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using RamblerAcademyAPI.GraphQL.GraphQLUserErrors;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class CourseSectionDayTimeSlotMutation : ObjectGraphType, IGraphQLMutation
    {
        public CourseSectionDayTimeSlotMutation(ICourseSectionDayTimeSlotRepository repository)
        {
            // createCourseSectionDayTimeSlot(courseSectionDayTimeSlot)
            Field<CourseSectionDayTimeSlotType>(
                "createCourseSectionDayTimeSlot",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CourseSectionDayTimeSlotInputType>> 
                            { Name = "courseSectionDayTimeSlot"}
                ),
                resolve: context =>
                {
                    var courseSectionDayTimeSlot = context.GetArgument<CourseSectionDayTimeSlot>("courseSectionDayTimeSlot");
                    return repository.CreateCourseSectionDayTimeSlot(courseSectionDayTimeSlot);
                }
            );

            // deleteCourseSectionDayTimeSlot(crn, dayId, timeSlotId)
            Field<StringGraphType>(
                "deleteCourseSectionDayTimeSlot",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "crn" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "dayId" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "timeSlotId" }
                ),
                resolve: context =>
                {
                    int crn = context.GetArgument<int>("crn");
                    int dayId = context.GetArgument<int>("dayId");
                    int timeSlotId = context.GetArgument<int>("timeSlotId");

                    var csdt = repository.GetCourseSectionDayTimeSlotByIds(crn, dayId, timeSlotId);
                    if(csdt == null)
                    {
                        context.Errors.Add(NotFoundError());
                        return null;
                    }
                    repository.DeleteCourseSectionDayTimeSlot(csdt);
                    return $"The CourseSectionDayTimeSlot with the crn of {crn}, dayId of {dayId}, and timeSlotId of {timeSlotId}"
                        + " has been successfully deleted";
                }
            );

        }

        private ExecutionError NotFoundError()
        {
            return new ExecutionError(GraphQLUserError.NotFoundString("CourseSectionDayTimeSlot"));
        }
    }
}
