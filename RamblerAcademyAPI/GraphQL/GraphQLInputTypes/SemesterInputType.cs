using GraphQL.Types;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class SemesterInputType : InputObjectGraphType
    {
        public SemesterInputType()
        {
            Name = "semesterInput";
            Field<NonNullGraphType<IntGraphType>>("year");
            Field<NonNullGraphType<DateTimeGraphType>>("startDate");
            Field<NonNullGraphType<DateTimeGraphType>>("endDate");
            Field<NonNullGraphType<IntGraphType>>("seasonId");
        }
    }
}
