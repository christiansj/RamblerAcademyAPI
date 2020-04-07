using GraphQL.Types;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class EnrollmentInputType : InputObjectGraphType
    {
        public EnrollmentInputType()
        {
            Name = "enrollmentInput";
            Field<NonNullGraphType<IdGraphType>>("studentId");
            Field<NonNullGraphType<IdGraphType>>("courseReferenceNumber");
        }
    }
}
