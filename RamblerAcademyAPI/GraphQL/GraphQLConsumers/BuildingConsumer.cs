using Newtonsoft.Json;
using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers.Util;
using System;
using RamblerAcademyAPI.GraphQL.GraphQLUserErrors;
using GraphQL;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class BuildingConsumer
    {
        private readonly GraphQLClient _client;
        private string buildingFragment = @"
                id
                name
                classrooms{
                    id
                    floor
                    hallwayNumber
                    roomNumber
                }
         ";

        public BuildingConsumer(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<List<Building>> GetAllBuildings()
        {
            string query = string.Format(@"
                {{
                    buildings{{
                        {0}
                    }}
                }}", buildingFragment);

            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "buildings");
            return JsonConvert.DeserializeObject<List<Building>>(data);
        }

        public async Task<Building> GetBuildingById(int buildingId)
        {
            string query = string.Format(@"
                {{
                    building(id: {0}){{
                        {1}
                    }}
                }} 
            ", buildingId, buildingFragment);
         
            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "building");
            return JsonConvert.DeserializeObject<Building>(data);
        }

        public async Task<Building> CreateBuilding(Building building)
        {
            string mutation = string.Format(@"
                mutation{{
                    createBuilding(building: {0}){{
                        id
                        name
                    }}
                }}    
            ", buildingInput(building));

            string resultString = await _client.Query(mutation);
            var data = DataParser.ParseDataFromString(resultString, "createBuilding");
            return JsonConvert.DeserializeObject<Building>(data);
        }

        public async Task<Building> UpdateBuilding(int buildingId, Building building)
        {
            string mutation = string.Format(@"
                mutation{{
                    updateBuilding(buildingId: {0}, building: {1}){{
                        {2}
                    }}
                }}
            ", buildingId, buildingInput(building), buildingFragment);

            string resultString = await _client.Query(mutation);
            var data = DataParser.ParseDataFromString(resultString, "updateBuilding");
            return JsonConvert.DeserializeObject<Building>(data);
        }

        public async Task<bool> DeleteBuilding(int buildingId)
        {
            string mutation = string.Format(@"
                mutation{{
                    deleteBuilding(buildingId: {0})
                }}
            ", buildingId);

            await _client.Query(mutation);
            return true;
        }

        private string buildingInput(Building building)
        {
            return string.Format("{{ name: \"{0}\" }}", building.Name);
        }
    }
}
