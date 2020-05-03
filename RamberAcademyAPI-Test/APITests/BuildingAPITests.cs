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

        [Fact]
        public async void GET_BuildingsTest()
        {
            await API_GetAllRecordsTest(TestData.Buildings());
        } 

        [Fact]
        public async void GET_BuildingTest()
        {
            const int buildingId = 1;
            Building expected = TestData.Buildings().Find(b => b.Id == buildingId);

            await API_GetExistentRecordTest(buildingId, expected);
        }

        [Fact]
        public async void GET_NonExistentBuildingTest()
        {
            const int buildingId = 1000;

            var response = await _controller.Get(buildingId) as NotFoundResult;

            Assert.NotNull(response);
        }

        [Fact]
        public async void POST_BuildingTest()
        {
            int buildingId = _TestDataCnt+1;
            Building expected = new Building(buildingId, "New Test Building");

            var response = await _controller.Post(expected) as OkObjectResult;
            Assert.NotNull(response);

            var actual = (Building)response.Value;
            Assert.NotNull(actual);

            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentRecordAsync(buildingId));
        }

        [Fact]
        public async void PUT_BuildingTest()
        {
            int buildingId = 2;
            Building expected = new Building(buildingId, "Updated Test Building");

            var response = await _controller.Put(buildingId, expected) as OkObjectResult;
            Assert.NotNull(response);

            var actual = (Building)response.Value;
            Assert.NotNull(actual);

            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentRecordAsync(buildingId));
        }

        [Fact]
        public async void PUT_NonExistentBuildingTest()
        {
            const int buildingId = 1000;

            var response = await _controller.Put(buildingId, new Building(buildingId, "Bad Test Building")) as NotFoundResult;

            Assert.NotNull(response);
        }

        [Fact]
        public async void DELETE_BuildingTest()
        {
            const int buildingId = 1;

            var response = await _controller.Delete(buildingId) as OkResult;
            var getResponse = await _controller.Get(buildingId) as NotFoundResult;

            Assert.NotNull(response);
            Assert.NotNull(getResponse);
        }

        [Fact]
        public async void DELETE_NonExistentBuildingTest()
        {
            const int buildingId = 1000;

            var response = await _controller.Delete(buildingId) as NotFoundResult;

            Assert.NotNull(response);
        }
    }
}
