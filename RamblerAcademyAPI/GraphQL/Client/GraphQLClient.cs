using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace RamblerAcademyAPI.GraphQL.Client
{
    public class GraphQLClient
    {
        public const string GraphqlAddress = "https://localhost:5001/graphql";

        private readonly HttpClient _client;
        
        public GraphQLClient(HttpClient httpClient)
        {
            _client = httpClient;
        }

        public async Task<string> Query(string query, string queryName)
        {
            query = string.Format("{{ {0} }}", query);
            return await Request(query, queryName);
        }


        public async Task<string> Mutation(string mutation, string mutationName)
        {
            mutation = string.Format("mutation{{ {0} }}", mutation);
            return await Request(mutation, mutationName);
        }

        private async Task<string> Request(string requestString, string requestName)
        {
            var response = await _client.GetAsync($"?query={requestString}");
            string contentString = await response.Content.ReadAsStringAsync();

            var errors = JObject.Parse(contentString)["errors"];
            if (errors != null)
            {
                string error = errors[0]["message"].ToString();
                throw new Exception(error);
            }
            return JObject.Parse(contentString)["data"][requestName].ToString();
            
        }
    }
}
