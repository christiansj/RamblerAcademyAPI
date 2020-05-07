using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class CourseSectionDayTimeSlotQuery : ObjectGraphType, IGraphQLQuery
    {
        public CourseSectionDayTimeSlotQuery(ICourseSectionDayTimeSlotRepository repository)
        {
            // courseSectionDayTimeSlots
            Field<ListGraphType<CourseSectionDayTimeSlotType>>(
                "courseSectionDayTimeSlots",
                resolve: context => repository.GetAll()
            );

            // courseSectionDayTimeSlotsPerDay(dayId)
            Field<ListGraphType<CourseSectionDayTimeSlotType>>(
                "courseSectionDayTimeSlotsPerDay",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "dayId" }
                ),
                resolve: context =>
                {
                    int dayId = context.GetArgument<int>("dayId");
                    return repository.GetAllCourseSectionDayTimeSlotsPerDay(dayId);
                }
            );

            // courseSectionDayTimeSlotsPerCourseSection(crn)
            Field<ListGraphType<CourseSectionDayTimeSlotType>>(
                "courseSectionDayTimeSlotsPerCourseSection",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "crn"}
                ),
                resolve: context =>
                {
                    int crn = context.GetArgument<int>("crn");
                    return repository.GetAllCourseSectionDayTimeSlotsPerCourseSection(crn);
                }
            );

            // courseSectionDayTimeSlot(crn, dayId, timeSlotId)
            Field<CourseSectionDayTimeSlotType>(
                "courseSectionDayTimeSlot",
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

                    return repository.GetCourseSectionDayTimeSlotByIds(crn, dayId, timeSlotId);
                }
            );
        }
    }
}
