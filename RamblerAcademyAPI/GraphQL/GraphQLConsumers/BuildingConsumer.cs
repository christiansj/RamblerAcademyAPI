using Newtonsoft.Json;
using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers.Util;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class BuildingConsumer
    {
        private readonly GraphQLClient _client;

        public BuildingConsumer(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<List<Building>> GetAllBuildings()
        {
            string query = @"
                {
                    buildings{
                        id
                        name
                        classrooms{
                            id
                            floor
                            hallwayNumber
                            roomNumber
                        }
                    }
                }";

            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "buildings");
            return JsonConvert.DeserializeObject<List<Building>>(data);
        }

        public async Task<Building> CreateBuilding(Building building)
        {
            string inStr = @"
                mutation{{
                    createBuilding(building: {0}){{
                        id
                        name
                    }}
                }}    
            ";

            string mutation = string.Format(inStr, buildingInput(building));
            string resultString = await _client.Query(mutation);
            var data = DataParser.ParseDataFromString(resultString, "createBuilding");
            return JsonConvert.DeserializeObject<Building>(data);
        }

        private string buildingInput(Building building)
        {
            return string.Format("{{ name: \"{0}\" }}", building.Name);
        }
    }
}
