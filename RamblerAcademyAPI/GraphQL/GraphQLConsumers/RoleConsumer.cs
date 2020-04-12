using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;

using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RamblerAcademyAPI.Util;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class RoleConsumer
    {
        private readonly GraphQLClient _client;
        private readonly string roleFragment = @"
               id name users{ id abcId firstName lastName email }
            ";
        public RoleConsumer(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Role>> GetAllRolesAsync()
        {
            string query = $"roles{{{roleFragment}}}";
            string data = await _client.Query(query, "roles");

            return JsonConvert.DeserializeObject<IEnumerable<Role>>(data);
        }

        public async Task<Role> GetRoleByIdAsync(int roleId)
        {
            string query = $"role(id: {roleId}){{{roleFragment}}}";
            string data = await _client.Query(query, "role");

            return JsonConvert.DeserializeObject<Role>(data);
        }

        public async Task<Role> CreateRoleAsync(Role role)
        {
            string mutation = $@"
                    createRole(role: {roleInput(role)}){{{roleFragment}}}";
            string data = await _client.Mutation(mutation, "createRole");

            return JsonConvert.DeserializeObject<Role>(data);
        }

        public async Task<Role> UpdateRoleAsync(int roleId, Role role)
        {
            string mutation = $@"updateRole(roleId: {roleId} role: {roleInput(role)}){{
                                {roleFragment} }}";
            string data = await _client.Mutation(mutation, "updateRole");

            return JsonConvert.DeserializeObject<Role>(data);
        }

        public async Task<bool> DeleteRoleAsync(int roleId)
        {
            await _client.Mutation($"deleteRole(roleId: {roleId})", "deleteRole");
            return true;
        }

        private string roleInput(Role role)
        {
            return $"{{ name: \"{role.Name}\"}}";
        }
    }
}
