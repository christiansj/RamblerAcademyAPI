using GraphQL.Types;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class SeasonInputType : InputObjectGraphType
    {
        public SeasonInputType()
        {
            Name = "seasonInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
    
}
