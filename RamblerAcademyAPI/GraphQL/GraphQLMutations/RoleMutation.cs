using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using RamblerAcademyAPI.GraphQL.GraphQLUserErrors;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class RoleMutation : ObjectGraphType, IGraphQLMutation
    {
        public RoleMutation(IRoleRepository repository)
        {
            // createRole(role)
            Field<RoleType>(
                "createRole",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<RoleInputType>> { Name = "role"}
                ),
                resolve: context =>
                {
                    var role = context.GetArgument<Role>("role");
                    return repository.CreateRole(role);
                }
            );

            // updateRole(role, roleId)
            Field<RoleType>(
                "updateRole",
                arguments: new QueryArguments(
                     new QueryArgument<NonNullGraphType<RoleInputType>> { Name = "role" },
                     new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "roleId" }
                ),
                resolve: context =>
                {
                    int roleId = context.GetArgument<int>("roleId");
                    var role = context.GetArgument<Role>("role");

                    var dbRole = repository.GetRoleById(roleId);
                    if(dbRole == null)
                    {
                        context.Errors.Add(NotFoundError());
                        return null;
                    }
                    return repository.UpdateRole(dbRole, role);
                }
            );

            // deleteRole(role)
            Field<StringGraphType>(
                "deleteRole",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "roleId" }
                ),
                resolve: context =>
                {
                    int roleId = context.GetArgument<int>("roleId");

                    var role = repository.GetRoleById(roleId);
                    if(role == null)
                    {
                        context.Errors.Add(NotFoundError());
                        return null;
                    }

                    repository.DeleteRole(role);
                    return $"The role with the id {roleId} has been successfully deleted";
                }
            );
        }

        private ExecutionError NotFoundError()
        {
            return new ExecutionError(GraphQLUserError.NotFoundString("Role"));
        }
    }
}
