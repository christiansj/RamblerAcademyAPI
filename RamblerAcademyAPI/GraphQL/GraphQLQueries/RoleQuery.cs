using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class RoleQuery : ObjectGraphType, IGraphQLQuery
    {
        public RoleQuery(IRoleRepository repository)
        {
            Field<ListGraphType<RoleType>>(
                "roles",
                resolve: context => repository.GetAll()
            );

            Field<RoleType>(
                "role",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id"}
                ),
                resolve: context =>
                {
                    int roleId = context.GetArgument<int>("id");
                    return repository.GetRoleById(roleId);
                }
            );
        }
    }
}
