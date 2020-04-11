using GraphQL.Types;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class TimeSlotInputType : InputObjectGraphType
    {
        public TimeSlotInputType()
        {
            Name = "timeSlotInput";
            Field<NonNullGraphType<TimeSpanSecondsGraphType>>("startTime");
            Field<NonNullGraphType<TimeSpanSecondsGraphType>>("endTime");
        }
    }
}
