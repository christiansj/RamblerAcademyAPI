using Newtonsoft.Json;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.Models;
using RamblerAcademyAPI.Util;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test.GraphQLTests
{
    [Collection("Role GraphQL Tests")]
    public class RoleGraphQLTests : GraphQLIntegrationTest<Role>
    {
        private readonly int _TestDataCnt;
        private readonly string fragment = "id name";
        public RoleGraphQLTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Roles().Count;
        }

        [Fact]
        public async void RolesQueryTest()
        {
            List<Role> roles = await ListQueryRequest($"roles{{{fragment}}}", "roles");

            AssertObjectsAreEqual(TestData.Roles(), roles);
        }

        [Fact]
        public async void RoleQueryTest()
        {
            const int roleId = 2;
            Role expectedRole = TestData.Roles().Find(r => r.Id == roleId);

            Role role = await GetRoleAsync(roleId);

            AssertObjectsAreEqual(expectedRole, role);
        }

        [Fact]
        public async void RoleCreateMutationTest()
        {
            Role expectedRole = new Role(_TestDataCnt + 1, "New Test Role");
            string mutation = $"createRole(role: {RoleInput(expectedRole)}){{{fragment}}}";

            var createTask = MutationRequest(mutation, "createRole");
            createTask.Wait();

            AssertObjectsAreEqual(expectedRole, createTask.Result);
            AssertObjectsAreEqual(expectedRole, await GetRoleAsync(expectedRole.Id));
            await AssertRecordCount(_TestDataCnt + 1, "roles", fragment);
        }

        [Fact]
        public async void RoleUpdateMutationTest()
        {
            const int RoleId = 1;
            Role expectedRole = new Role(RoleId, "Updated Test Role");
            string mutation = $"updateRole(roleId: {RoleId}, role:{RoleInput(expectedRole)}){{{fragment}}}";

            Role newRole = await MutationRequest(mutation, "updateRole");

            AssertObjectsAreEqual(expectedRole, newRole);
        }

        [Fact]
        public async void RoleDeleteMutationTest()
        {
            const int RoleId = 1;
            string mutation = $"mutation{{deleteRole(roleId: {RoleId})}}";

            var deleteTask = GraphQLRequest(mutation, "deleteRole");
            deleteTask.Wait();

            await AssertRecordCount(_TestDataCnt - 1, "roles", fragment);
            Assert.Null(await GetRoleAsync(RoleId));
        }

        private string RoleInput(Role role)
        {
            var fields = new RoleInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, role);
        }

        private async Task<Role> GetRoleAsync(int roleId)
        {
            string query = $"role(id: {roleId}){{{fragment}}}";
            return await SingleQueryRequest(query, "role");
        }
    }
}
