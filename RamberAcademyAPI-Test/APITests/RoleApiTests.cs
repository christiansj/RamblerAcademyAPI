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
    public class RoleApiTests : AbstractOneIdApiTest<Role>
    {
        private readonly int _TestDataCnt;
        private readonly RoleConsumer _consumer;

        public RoleApiTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Roles().Count;
            _consumer = new RoleConsumer(_factory);
            _controller = new RoleController(_consumer);
        }

        // GET /api/role
        [Fact]
        public async void GET_RolesTest()
        {
            await API_GetAllRecordsTest(TestData.Roles());
        }

        // GET /api/role/{id}
        [Fact]
        public async void GET_RoleTest()
        {
            const int roleId = 1;
            Role expected = TestData.Roles().Find(r => r.Id == roleId);

            await API_GetExistentRecordTest(1, expected);
        }

        // GET /api/role/{id}
        [Fact]
        public async void GET_NonExistenetRoleTest()
        {
            const int roleId = 10000;

            var result = await _controller.Get(roleId) as NotFoundResult;

            Assert.NotNull(result);
        }

        // POST /api/role
        [Fact]
        public async void POST_RoleTest()
        {
            Role expected = new Role(_TestDataCnt + 1, "New Test Role");

            await API_PostRecordTest(_TestDataCnt, expected);
        }

        // PUT /api/role/{id}
        [Fact]
        public async void PUT_RoleTest()
        {
            const int roleId = 2;
            Role expected = new Role(roleId, "Updated role Name");

            await API_PutRecordTest(roleId, expected);
        }

        // PUT /api/role/{id}
        [Fact]
        public async void PUT_NonExistentRoleTest()
        {
            const int roleId = 100000;

            var result = await _controller.Put(roleId, new Role(roleId, "Bad Role")) as NotFoundResult;

            Assert.NotNull(result);
        }

        // DELETE /api/role/{id}
        [Fact]
        public async void DELETE_RoleTest()
        {
            await API_DeleteRecordTest(1);
        }

        // DELETE /api/role/{id}
        [Fact]
        public async void DELETE_NonExistenetRoleTest()
        {
            const int roleId = 1000000;

            var result = await _controller.Delete(roleId) as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}
