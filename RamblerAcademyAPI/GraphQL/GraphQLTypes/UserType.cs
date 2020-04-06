using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class UserType : ObjectGraphType<User>
    {
        public UserType(IRoleRepository roleRepository)
        {
            Field(u => u.Id, type: typeof(IdGraphType))
                .Description("Id property of the User object. Primary Key");

            Field(u => u.AbcId, type: typeof(StringGraphType))
                .Description("AbcId property of the User object. First 3 chars are alphabetic, last 3 chars are numeric. Unique Index");

            Field(u => u.FirstName, type: typeof(StringGraphType))
                .Description("FirstName property of the User object");

            Field(u => u.LastName, type: typeof(StringGraphType))
                .Description("LastName property of the User object");

            Field(u => u.Email, type: typeof(StringGraphType))
                .Description("Email property of the User object. Unique index");

            Field(u => u.Password, type: typeof(StringGraphType))
                .Description("Password property of the User object.");

            Field(u => u.RoleId, type: typeof(IntGraphType))
                .Description("RoleId property of the User object. References the RoleId property of a Roel object");

            Field<RoleType>(
                "role",
                resolve: context=>roleRepository.GetRoleById(context.Source.RoleId)
            );
        }
    }
}
