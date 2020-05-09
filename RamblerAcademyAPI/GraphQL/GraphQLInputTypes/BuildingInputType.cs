using GraphQL.Types;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class BuildingInputType : InputObjectGraphType
    {
        public BuildingInputType()
        {
            Name = "buildingInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("abbreviation");
        }
    }
}
