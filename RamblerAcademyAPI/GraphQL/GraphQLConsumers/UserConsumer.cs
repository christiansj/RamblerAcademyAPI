using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;

using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RamblerAcademyAPI.Util;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class UserConsumer
    {
        private readonly GraphQLClient _client;
        private readonly string userFragment = @"
            id
            abcId
            firstName
            lastName
            email
            password
            role{
                id
                name
            }
        ";

        public UserConsumer(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            string query = string.Format("users{{ {0} }}", userFragment);

            string data = await _client.Query(query, "users");
            return JsonConvert.DeserializeObject<IEnumerable<User>>(data);
        }

        public async Task<User> GetUserByIdAsync(long id)
        {
            string query = string.Format("user(id: {0}){{ {1} }}",
                            id, userFragment);

            string data = await _client.Query(query, "user");
            return JsonConvert.DeserializeObject<User>(data);
        }

        public async Task<User> CreateUserAsync(User user)
        {
            string mutation = string.Format(@"
                createUser(user: {0}){{ {1} }}
            ", userInput(user), userFragment);

            string data = await _client.Mutation(mutation, "createUser");
            return JsonConvert.DeserializeObject<User>(data);
        }

        public async Task<User> UpdateUserAsync(long id, User user)
        {
            string mutation = string.Format(@"
                updateUser(userId: {0}, user: {1}){{ {2} }}
            ", id, userInput(user), userFragment);

            string data = await _client.Mutation(mutation, "updateUser");
            return JsonConvert.DeserializeObject<User>(data);
        }

        public async Task<bool> DeleteUserAsync(long id)
        {
            string mutation = $"deleteUser(userId: {id})";
            await _client.Mutation(mutation, "deleteUser");

            return true;
        }

        private string userInput(User user)
        {
            var fields = new UserInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, user);
        }
    }
}
