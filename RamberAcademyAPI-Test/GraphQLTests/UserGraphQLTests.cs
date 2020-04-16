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
    [Collection("User GraphQL Tests")]
    public class UserGraphQLTests : GraphQLIntegrationTest<User>
    {
        private readonly int _TestDataCnt;
        private readonly string fragment = "id abcId firstName lastName email password roleId";
        public UserGraphQLTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Users().Count;
        }

        [Fact]
        public async void UsersQueryTest()
        {
            List<User> users = await ListQueryRequest($"users{{{fragment}}}", "users");

            AssertObjectsAreEqual(TestData.Users(), users);
        }

        [Fact]
        public async void UserQueryTest()
        {
            const int userId = 2;
            User expectedUser = TestData.Users().Find(u => u.Id == userId);

            User user = await GetUserAsync(userId);

            AssertObjectsAreEqual(expectedUser, user);
        }

        [Fact]
        public async void UserCreateMutationTest()
        {
            User expectedUser = new User(_TestDataCnt + 1, "fji349", "New Test", "User", "newTest@example.com", "password", 1);
            string mutation = $"createUser(user: {UserInput(expectedUser)}){{{fragment}}}";

            var createTask = MutationRequest(mutation, "createUser");
            createTask.Wait();

            AssertObjectsAreEqual(expectedUser, createTask.Result);
            await AssertRecordCount(_TestDataCnt + 1, "users", fragment);
        } 

        [Fact]
        public async void UserUpdateMutationTest()
        {
            const long UserId = 2;
            User ExpectedUser = new User(UserId, "new348", "Updated Test", "User", "updateUser@example.com", "password", 1);
            string mutation = $"updateUser(userId: {UserId}, user: {UserInput(ExpectedUser)}){{{fragment}}}";

            User NewUser = await MutationRequest(mutation, "updateUser");

            AssertObjectsAreEqual(ExpectedUser, NewUser);
            AssertObjectsAreEqual(ExpectedUser, await GetUserAsync(UserId));
        }

        [Fact]
        public async void UserDeleteMutationTest()
        {
            const long userId = 1;
            string mutation = $"mutation{{deleteUser(userId: {userId})}}";

            var deleteTask = GraphQLRequest(mutation, "deleteUser");
            deleteTask.Wait();

            await AssertRecordCount(_TestDataCnt - 1, "users", fragment);
            Assert.Null(await GetUserAsync(userId));
        }

        private async Task<User> GetUserAsync(long userId)
        {
            string query = $"user(id: {userId}){{{fragment}}}";

            return await SingleQueryRequest(query, "user");
        }

        private string UserInput(User user)
        {
            var fields = new UserInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, user);
        }
    }
}
