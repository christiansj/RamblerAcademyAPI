using GraphQL.Types;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class DayTimeSlotInputType : InputObjectGraphType
    {
        public DayTimeSlotInputType()
        {
            Name = "dayTimeSlotInput";
            Field<NonNullGraphType<IdGraphType>>("dayId");
            Field<NonNullGraphType<IdGraphType>>("timeSlotId");
        }
    }
}
