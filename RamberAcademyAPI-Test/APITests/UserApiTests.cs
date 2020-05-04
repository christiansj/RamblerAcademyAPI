using Microsoft.AspNetCore.Mvc;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.Controllers;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers;
using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test.APITests
{
    public class UserApiTests : AbstractOneIdApiTest<User>
    {
        private readonly int _TestDataCnt;
        private readonly UserConsumer _consumer;
        private readonly UserController userController;
        public UserApiTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Users().Count;
            _consumer = new UserConsumer(_factory);
            userController = new UserController(_consumer);
            _controller = userController;
        }

        // GET /api/user
        [Fact]
        public async void GET_UsersTest()
        {
            var expected = TestData.Users();

            var result = await userController.Get() as OkObjectResult;
            Assert.NotNull(result);
            var actual = (IEnumerable<User>)result.Value;

            Assert.NotNull(actual);
            AssertListsAreEqual(expected, actual);
        }

        // GET /api/user/{id}
        [Fact]
        public async void GET_UserTest()
        {
            const long userId = 2;
            User expected = TestData.Users().Find(u => u.Id == userId);

            var actual = await GetExistentUserAsync(userId);

            AssertObjectsAreEqual(expected, actual);
        }

        // GET /api/user/{id}
        [Fact]
        public async void GET_NonExistenetUserTest()
        {
            const long userId = 100000;

            var result = await userController.Get(userId) as NotFoundResult;

            Assert.NotNull(result);
        }

        // POST /api/user
        [Fact]
        public async void POST_UserTest()
        {
            User expected = new User(_TestDataCnt + 1, "gji489", "New", "User", "new@example.com", "newword", 2);

            var result = await userController.Post(expected) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (User)result.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentUserAsync(_TestDataCnt + 1));
        }

        // PUT /api/user/{id}
        [Fact]
        public async void PUT_UserTest()
        {
            const long userId = 2;
            var expected = new User(userId, "fji384", "Updated", "Last", "update@example.com", "password", 1);

            var result = await userController.Put(userId, expected) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (User)result.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentUserAsync(userId));
        }

        // PUT /api/user/{id}
        [Fact]
        public async void PUT_NonExistentUserTest()
        {
            const long userId = 10000;
            User badUser = new User(userId, "fji356", "Bad", "User", "bad@example.com", "badword", 2);

            var result = await userController.Put(userId, badUser) as NotFoundResult;

            Assert.NotNull(result);
        }

        // DELETE /api/user/{id}
        [Fact]
        public async void DELETE_UserTest()
        {
            const long userId = 4;

            var deleteResult = await userController.Delete(userId) as OkResult;
            var getResult = await userController.Get(userId) as NotFoundResult;

            Assert.NotNull(deleteResult);
            Assert.NotNull(getResult);
        }

        // DELETE /api/user/{id}
        [Fact]
        public async void DELETE_NonExistentUserTest()
        {
            const long userId = 100000;

            var result = await userController.Delete(userId) as NotFoundResult;

            Assert.NotNull(result);
        } 

        private async Task<User> GetExistentUserAsync(long userId)
        {
            var result = await userController.Get(userId) as OkObjectResult;
            Assert.NotNull(result);

            return (User)result.Value;
        }
    }
}
