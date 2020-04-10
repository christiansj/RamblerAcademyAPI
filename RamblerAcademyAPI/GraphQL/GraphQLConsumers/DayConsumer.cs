using Newtonsoft.Json;
using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using RamblerAcademyAPI.GraphQL.GraphQLConsumers.Util;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class DayConsumer
    {
        private readonly GraphQLClient _client;
        private string dayFragment = @"
            id
            name
        ";
        public DayConsumer(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Day>> GetAllDaysAsync()
        {
            string query = string.Format(@"
                {{
                    days{{
                        {0}
                    }}
                }}
            ", dayFragment);

            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "days");
            return JsonConvert.DeserializeObject<IEnumerable<Day>>(data);
        }

        public async Task<Day> GetDayByIdAsync(int dayId)
        {
            string query = string.Format(@"
                {{
                    day(id: {0}){{
                        {1}
                    }}
                }}
            ", dayId, dayFragment);

            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "day");
            return JsonConvert.DeserializeObject<Day>(data);
        }
    }
}
