using Newtonsoft.Json;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;

using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test
{
    public class BuildingQueryTests : IntegrationTest
    {
        private readonly ITestOutputHelper output;
        
        public BuildingQueryTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        private List<Building> Buildings()
        {
            List<Building> buildings = new List<Building>();
            buildings.Add(new Building(1, "Test Building 1"));
            buildings.Add(new Building(2, "Test Building 2"));
            return buildings;
        }
        [Fact]
        public async void BuildingsQueryTest()
        {
            var response = await QueryRequest("buildings{id name}");
            string contentString = await response.Content.ReadAsStringAsync();
            string data = Utilities.ParseData(contentString, "buildings");
            
            output.WriteLine(data);

            List<Building> buildings = JsonConvert.DeserializeObject<List<Building>>(data);
            Assert.Equal(TestData.Buildings().Count, buildings.Count);

            AssertObjectsAreEqual(TestData.Buildings(), buildings);
        }

        [Fact]
        public async void BuildingQueryTest()
        {
            var response = await QueryRequest("building(id: 2){id name}");
            string contentString = await response.Content.ReadAsStringAsync();
            string data = Utilities.ParseData(contentString, "building");

            output.WriteLine(data);

            Building building = JsonConvert.DeserializeObject<Building>(data);
            Building expectedBuilding = TestData.Buildings().Find(b => b.Id == 2);

            AssertObjectsAreEqual(building, expectedBuilding);
        }
    }
}
