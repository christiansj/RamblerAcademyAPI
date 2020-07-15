using Newtonsoft.Json;
using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using System.Net.Http;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class BuildingConsumer
    {
        private readonly GraphQLClient _client;
        private string buildingFragment = @"
                id
                name
                abbreviation
                classrooms{
                    id
                    floor
                    hallwayNumber
                    roomNumber
                    building { id name abbreviation }
                }
         ";

        public BuildingConsumer(IHttpClientFactory factory)
        {
            _client = new GraphQLClient(factory.CreateClient(name: "graphQLClient"));
        }

        public async Task<List<Building>> GetAllBuildings()
        {
            string query = string.Format("buildings{{ {0} }} ", buildingFragment);

            var data = await _client.Query(query, "buildings");
            return JsonConvert.DeserializeObject<List<Building>>(data);
        }

        public async Task<Building> GetBuildingById(int buildingId)
        {
            string query = string.Format(@"
                    building(id: {0}){{
                        {1}
                    }}
            ", buildingId, buildingFragment);
         
            string data = await _client.Query(query, "building");
            return JsonConvert.DeserializeObject<Building>(data);
        }

        public async Task<Building> CreateBuilding(Building building)
        {
            string mutation = string.Format(@"
                    createBuilding(building: {0}){{
                        {1}
                    }}
            ", buildingInput(building), buildingFragment);

            string data = await _client.Mutation(mutation, "createBuilding");
            return JsonConvert.DeserializeObject<Building>(data);
        }

        public async Task<Building> UpdateBuilding(int buildingId, Building building)
        {
            string mutation = string.Format(@"
                    updateBuilding(buildingId: {0}, building: {1}){{
                        {2}
                    }}
            ", buildingId, buildingInput(building), buildingFragment);

            string data = await _client.Mutation(mutation, "updateBuilding");
            return JsonConvert.DeserializeObject<Building>(data);
        }

        public async Task<bool> DeleteBuilding(int buildingId)
        {
            await _client.Mutation($"deleteBuilding(buildingId: {buildingId})", "deleteBuilding");
            return true;
        }

        private string buildingInput(Building building)
        {
            return string.Format("{{ name: \"{0}\", abbreviation: \"{1}\" }}", building.Name, building.Abbreviation);
        }
    }
}
