using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;


namespace RamberAcademyAPI_Test.GraphQLTests
{
    [Collection("Building GraphQL Tests")]
    public class BuildingGraphQLTests : GraphQLIntegrationTest<Building>
    {
        
        private readonly int _TestDataCnt;
        private const string fragment = "id name";
        public BuildingGraphQLTests(ITestOutputHelper output) :base(output)
        {
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
            Building expectedNewBuilding = new Building(expectedBuildingCnt, "New Test Building", "NTB");

            var createTask =  MutationRequest(mutation, "createBuilding");
            createTask.Wait();
          
            AssertObjectsAreEqual(expectedNewBuilding, createTask.Result);
            await AssertRecordCount(_TestDataCnt + 1, "buildings", fragment);
        }


        // updateBuilding(buildingId, building)
        [Fact]
        public async void BuilidingUpdateMutationTest()
        {
            const int buildingId = 2;
            const string buildingInput = "{name: \"Updated Test Building 2\"}";
            string mutation = @$"updateBuilding(buildingId: {buildingId}, building: {buildingInput})
                                {{id name}}";

            Building expectedNewBuilding = new Building(2, "Updated Test Building 2", "UTB");
            Building newBuilding = await MutationRequest(mutation, "updateBuilding");

            AssertObjectsAreEqual(newBuilding, expectedNewBuilding);
        }

        // deleteBuilding(buildingId)
        [Fact]
        public async void BuildingDeleteMutationTest()
        {
            const int buildingId = 1;
            string mutation = $"mutation{{deleteBuilding(buildingId: {buildingId})}}";

            var deleteTask =  GraphQLRequest(mutation, "deleteBuilding");
            deleteTask.Wait();

            await AssertRecordCount(_TestDataCnt - 1, "buildings", fragment);
        }

        private async Task<Building> GetBuildingRequestAsync(int buildingId)
        {
            return await SingleQueryRequest($"building(id: {buildingId}){{id name}}", "building");
        }
    }
}