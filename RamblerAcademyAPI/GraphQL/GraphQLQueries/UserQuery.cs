using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class UserQuery : ObjectGraphType, IGraphQLQuery
    {
        public UserQuery(IUserRepository repository)
        {
            // users
            Field<ListGraphType<UserType>>(
                "users",
                resolve: context=> repository.GetAll()
            );

            // users(id)
            Field<UserType>(
                "user",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: context =>
                {
                    int userId = context.GetArgument<int>("id");
                    return repository.GetUserById(userId);
                }
            );
        }
    }
}
