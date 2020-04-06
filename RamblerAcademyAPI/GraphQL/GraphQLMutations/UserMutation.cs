using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class UserMutation : ObjectGraphType, IGraphQLMutation
    {
        public UserMutation(IUserRepository repository)
        {
            // createUser(user)
            Field<UserType>(
                "createUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user" }
                ),
                resolve: context =>
                {
                    var user = context.GetArgument<User>("user");
                    return repository.CreateUser(user);
                }
            );

            // UpdateUser(user, userId)
            Field<UserType>(
                "updateUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>> { Name = "user"},
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId"}
                ),
                resolve: context =>
                {
                    int userId = context.GetArgument<int>("userId");
                    var user = context.GetArgument<User>("user");

                    var dbUser = repository.GetUserById(userId);
                    if(dbUser == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find User in db"));
                        return null;
                    }
                    return repository.UpdateUser(dbUser, user);
                }
            );

            Field<StringGraphType>(
                "deleteUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "userId" }
                ),
                resolve: context =>
                {
                    int userId = context.GetArgument<int>("userId");

                    var user = repository.GetUserById(userId);
                    if(user == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find the User in the db"));
                        return null;
                    }

                    repository.DeleteUser(user);
                    return $"The user with the id {userId} has been successfully deleted";
                }
            );
        }
    }
}
