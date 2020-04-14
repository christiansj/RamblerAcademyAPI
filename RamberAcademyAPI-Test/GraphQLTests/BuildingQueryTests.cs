using Newtonsoft.Json;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test
{
    public class BuildingQueryTests : GraphQLIntegrationTest<Building>
    {
        private readonly ITestOutputHelper output;
        private readonly int _TestDataCnt;

        public BuildingQueryTests(ITestOutputHelper output)
        {
            this.output = output;
            _TestDataCnt = TestData.Buildings().Count;
        }
        
        // buildings
        [Fact]
        public async void BuildingsQueryTest()
        { 
            List<Building> buildings = await ListQueryRequest("buildings{id name}", "buildings");
            Assert.Equal(TestData.Buildings().Count, buildings.Count);

            AssertObjectsAreEqual(TestData.Buildings(), buildings);
        }

        // building(id)
        [Fact]
        public async void BuildingQueryTest()
        {
            int buildingId = 2;
            Building expectedBuilding = TestData.Buildings().Find(b => b.Id == buildingId);

            Building building = await GetBuildingRequestAsync(buildingId);
            
            AssertObjectsAreEqual(building, expectedBuilding);
        }

        // createBuilding(building)
        [Fact]
        public async void BuildingCreateMutationTest()
        {
            const string buildingInput = "{name: \"New Test Building\"}";
            string mutation = $"createBuilding(building: {buildingInput}){{id name}}";
            int expectedBuildingCnt = _TestDataCnt + 1;
            Building expectedNewBuilding = new Building(expectedBuildingCnt, "New Test Building");

            string data = await MutationRequest(mutation, "createBuilding");
            Building newBuilding = JsonConvert.DeserializeObject<Building>(data);

            AssertObjectsAreEqual(newBuilding, expectedNewBuilding);
            AssertObjectsAreEqual(await GetBuildingRequestAsync(expectedBuildingCnt), expectedNewBuilding);
            await AssertBuildingCntAsync(expectedBuildingCnt);
        }

        // updateBuilding(buildingId, building)
        [Fact]
        public async void BuilidingUpdateMutationTest()
        {
            const int buildingId = 2;
            const string buildingInput = "{name: \"Updated Test Building 2\"}";
            string mutation = @$"updateBuilding(buildingId: {buildingId}, building: {buildingInput})
                                {{id name}}";
            Building expectedNewBuilding = new Building(2, "Updated Test Building 2");

            string data = await MutationRequest(mutation, "updateBuilding");
            Building newBuilding = JsonConvert.DeserializeObject<Building>(data);

            AssertObjectsAreEqual(newBuilding, expectedNewBuilding);
            await AssertBuildingCntAsync(_TestDataCnt);
        }

        // deleteBuilding(buildingId)
        [Fact]
        public async void buildingDeleteMutationTest()
        {
            const int buildingId = 1;
            string mutation = $"deleteBuilding(buildingId: {buildingId})";

            string data = await MutationRequest(mutation, "deleteBuilding");

            await AssertBuildingCntAsync(_TestDataCnt-1);
            Assert.Null(await GetBuildingRequestAsync(buildingId));
        }

        private async Task<Building> GetBuildingRequestAsync(int buildingId)
        {
            return await SingleQueryRequest($"building(id: {buildingId}){{id name}}", "building");
        }

        // assert: building count in db == {expectedCnt}
        private async Task<string> AssertBuildingCntAsync(int expectedCnt)
        {
            List<Building> buildings = await ListQueryRequest("buildings{id name}", "buildings");
            Assert.Equal(expectedCnt, buildings.Count);
            return null;
        }
    }
}