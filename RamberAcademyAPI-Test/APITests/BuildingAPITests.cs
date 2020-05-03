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
    public class BuildingAPITests : AbstractApiTest<Building>
    {
        private readonly int _TestDataCnt;
        private readonly BuildingConsumer _consumer;
        
        public BuildingAPITests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Buildings().Count;   
            _consumer = new BuildingConsumer(_factory);
            _controller = new BuildingController(_consumer);
        }

        // GET /api/building
        [Fact]
        public async void GET_BuildingsTest()
        {
            await API_GetAllRecordsTest(TestData.Buildings());
        }

        // GET /api/building/{id}
        [Fact]
        public async void GET_BuildingTest()
        {
            const int buildingId = 1;
            Building expected = TestData.Buildings().Find(b => b.Id == buildingId);

            await API_GetExistentRecordTest(buildingId, expected);
        }

        // GET /api/building/{id}
        [Fact]
        public async void GET_NonExistentBuildingTest()
        {
            const int buildingId = 1000;

            var response = await _controller.Get(buildingId) as NotFoundResult;

            Assert.NotNull(response);
        }

        // POST /api/building
        [Fact]
        public async void POST_BuildingTest()
        {
            Building expected = new Building(_TestDataCnt+1, "New Test Building");

            await API_PostRecordTest(_TestDataCnt, expected);
        }

        // PUT /api/building/{id}
        [Fact]
        public async void PUT_BuildingTest()
        {
            const int buildingId = 2;
            Building expected = new Building(buildingId, "Updated Test Building");

            await API_PutRecordTest(buildingId, expected);
        }

        // PUT /api/building/{id}
        [Fact]
        public async void PUT_NonExistentBuildingTest()
        {
            const int buildingId = 1000;

            var response = await _controller.Put(buildingId, new Building(buildingId, "Bad Test Building")) as NotFoundResult;

            Assert.NotNull(response);
        }

        // DELETE /api/building/{id}
        [Fact]
        public async void DELETE_BuildingTest()
        {
            await API_DeleteRecordTest(1);
        }

        // DELETE /api/building/{id}
        [Fact]
        public async void DELETE_NonExistentBuildingTest()
        {
            const int buildingId = 1000;

            var response = await _controller.Delete(buildingId) as NotFoundResult;

            Assert.NotNull(response);
        }
    }
}
