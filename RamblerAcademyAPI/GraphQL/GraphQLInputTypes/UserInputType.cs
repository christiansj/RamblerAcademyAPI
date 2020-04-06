using GraphQL.Types;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class UserInputType : InputObjectGraphType
    {
        public UserInputType()
        {
            Name = "userInput";
            Field<NonNullGraphType<StringGraphType>>("abcId");
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<StringGraphType>>("email");
            Field<NonNullGraphType<StringGraphType>>("password");
            Field<NonNullGraphType<IntGraphType>>("roleId");
        }
    }
}
