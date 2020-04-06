using GraphQL.Types;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class ClassroomInputType : InputObjectGraphType
    {
        public ClassroomInputType()
        {
            Name = "classroomInput";
            Field<NonNullGraphType<IntGraphType>>("floor"); 
            Field<NonNullGraphType<IntGraphType>>("hallwayNumber");
            Field<NonNullGraphType<IntGraphType>>("roomNumber");
            Field<NonNullGraphType<IntGraphType>>("buildingId");
        }
    }
}
