using Newtonsoft.Json;
using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using RamblerAcademyAPI.GraphQL.GraphQLConsumers;
using System.Net.Http;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class DayConsumer
    {
        private readonly GraphQLClient _client;
        private string dayFragment = @"
            id
            name
        ";
        public DayConsumer(IHttpClientFactory factory)
        {
            _client = new GraphQLClient(factory.CreateClient(name: "graphQLClient"));
        }

        public async Task<IEnumerable<Day>> GetAllDaysAsync()
        {
            string query = string.Format("days{{ {0} }}", dayFragment);

            string data = await _client.Query(query, "days");
            return JsonConvert.DeserializeObject<IEnumerable<Day>>(data);
        }

        public async Task<Day> GetDayByIdAsync(int dayId)
        {
            string query = string.Format(@"
                    day(id: {0}){{
                        {1}
                    }}
            ", dayId, dayFragment);

            string data = await _client.Query(query, "day");
            return JsonConvert.DeserializeObject<Day>(data);
        }
    }
}
