using GraphQL.Types;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class CourseSectionDayTimeSlotInputType : InputObjectGraphType
    {
        public CourseSectionDayTimeSlotInputType()
        {
            Name = "courseSectionDayTimeSlotInput";
            Field<NonNullGraphType<IdGraphType>>("courseReferenceNumber");
            Field<NonNullGraphType<IdGraphType>>("dayId");
            Field<NonNullGraphType<IdGraphType>>("timeSlotId");
        }
    }
}
