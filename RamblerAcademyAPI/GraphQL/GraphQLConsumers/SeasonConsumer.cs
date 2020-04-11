using Newtonsoft.Json;
using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using RamblerAcademyAPI.GraphQL.GraphQLConsumers.Util;
using System;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class SeasonConsumer
    {
        private readonly GraphQLClient _client;
        private string seasonFragment = @"
            id
            name
            semesters{
                id
                year
                startDate
                endDate
            }
        ";
        public SeasonConsumer(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Season>> GetAllSeasonsAsync()
        {
            string query = string.Format("seasons{{ {0} }}", 
                            seasonFragment);

            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "seasons");
            return JsonConvert.DeserializeObject<IEnumerable<Season>>(data);
        }

        public async Task<Season> GetSeasonByIdAsync(int seasonId)
        {
            string query = string.Format(@"
                    season(id: {0}){{
                        {1}
                    }}
            ", seasonId, seasonFragment);
        
            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "season");
            return JsonConvert.DeserializeObject<Season>(data);
        }

        public async Task<Season> CreateSeasonAsync(Season season)
        {
            string mutation = string.Format(@"
                    createSeason(season: {0}){{
                        {1}
                    }}
            ", seasonInput(season), seasonFragment);

            string resultString = await _client.Mutation(mutation);
            var data = DataParser.ParseDataFromString(resultString, "createSeason");
            return JsonConvert.DeserializeObject<Season>(data);
        }

        public async Task<Season> UpdateSeasonAsync(int seasonId, Season season)
        {
            string mutation = string.Format(@"
                    updateSeason(seasonId: {0}, season: {1}){{
                        {2}
                    }}
            ", seasonId, seasonInput(season), seasonFragment);

            string resultString = await _client.Mutation(mutation);
            var data = DataParser.ParseDataFromString(resultString, "updateSeason");
            return JsonConvert.DeserializeObject<Season>(data);
        }

        public async Task<bool> DeleteSeasonAsync(int seasonId)
        {
            await _client.Mutation($"deleteSeason(seasonId: {seasonId})");
            return true;
        }

        private string seasonInput(Season season)
        {
            return string.Format("{{ name: \"{0}\" }}", season.Name);
        }
    }
}
