using Newtonsoft.Json;
using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using RamblerAcademyAPI.GraphQL.GraphQLConsumers.Util;
using System;
using System.Net.Http;

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
        public SeasonConsumer(IHttpClientFactory factory)
        {
            _client = new GraphQLClient(factory.CreateClient(name: "graphQLClient"));
        }

        public async Task<IEnumerable<Season>> GetAllSeasonsAsync()
        {
            string query = string.Format("seasons{{ {0} }}", 
                            seasonFragment);

            string data = await _client.Query(query, "seasons");
            return JsonConvert.DeserializeObject<IEnumerable<Season>>(data);
        }

        public async Task<Season> GetSeasonByIdAsync(int seasonId)
        {
            string query = string.Format(@"
                    season(id: {0}){{
                        {1}
                    }}
            ", seasonId, seasonFragment);
        
            string data = await _client.Query(query, "season");
            return JsonConvert.DeserializeObject<Season>(data);
        }

        public async Task<Season> CreateSeasonAsync(Season season)
        {
            string mutation = string.Format(@"
                    createSeason(season: {0}){{
                        {1}
                    }}
            ", seasonInput(season), seasonFragment);

            string data = await _client.Mutation(mutation, "createSeason");
            return JsonConvert.DeserializeObject<Season>(data);
        }

        public async Task<Season> UpdateSeasonAsync(int seasonId, Season season)
        {
            string mutation = string.Format(@"
                    updateSeason(seasonId: {0}, season: {1}){{
                        {2}
                    }}
            ", seasonId, seasonInput(season), seasonFragment);

            string data = await _client.Mutation(mutation, "updateSeason");
            return JsonConvert.DeserializeObject<Season>(data);
        }

        public async Task<bool> DeleteSeasonAsync(int seasonId)
        {
            await _client.Mutation($"deleteSeason(seasonId: {seasonId})", "deleteSeason");
            return true;
        }

        private string seasonInput(Season season)
        {
            return string.Format("{{ name: \"{0}\" }}", season.Name);
        }
    }
}
