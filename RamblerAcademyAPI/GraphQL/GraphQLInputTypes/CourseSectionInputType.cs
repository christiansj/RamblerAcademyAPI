using GraphQL.Types;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class CourseSectionInputType : InputObjectGraphType
    {
        public CourseSectionInputType()
        {
            Name = "courseSectionInput";
            Field<NonNullGraphType<IdGraphType>>("courseReferenceNumber");
            Field<NonNullGraphType<IntGraphType>>("sectionNumber");
            Field<NonNullGraphType<IntGraphType>>("courseId");
            Field<NonNullGraphType<IntGraphType>>("semesterId");
            Field<NonNullGraphType<IntGraphType>>("classroomId");
        }
    }
}
