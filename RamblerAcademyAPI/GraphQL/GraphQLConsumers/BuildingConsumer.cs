using Newtonsoft.Json;
using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json.Linq;
using System;

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

            string result = await _client.Query(query);
            Console.WriteLine(result);
            var parsedResult = JObject.Parse(result)["data"]["buildings"].ToString();
            return JsonConvert.DeserializeObject<List<Building>>(parsedResult);
        }
    }
}
