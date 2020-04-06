using GraphQL.Types;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class RoleInputType : InputObjectGraphType
    {
        public RoleInputType()
        {
            Name = "roleInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
