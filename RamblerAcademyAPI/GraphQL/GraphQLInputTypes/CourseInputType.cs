using GraphQL.Types;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class CourseInputType : InputObjectGraphType
    {
        public CourseInputType()
        {
            Name = "courseInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<IntGraphType>>("courseNumber");
            Field<NonNullGraphType<IntGraphType>>("subjectId");
        }
    }
}
