using GraphQL.Types;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class RoleType : ObjectGraphType<Role>
    {
        public RoleType()
        {
            Field(r => r.Id, type: typeof(IdGraphType))
                .Description("Id property of the Role object. Primary Key");

            Field(r => r.Name, type: typeof(StringGraphType))
                .Description("Name property of the Role object. Unique Index");
        }
    }
}
