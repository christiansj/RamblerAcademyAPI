using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<string> Query(string query)
        {

            var response = await _client.GetAsync($"{GraphqlAddress}?query={query}");
            string contentString = await response.Content.ReadAsStringAsync();
            var errors = JObject.Parse(contentString)["errors"];
            if (errors != null)
            {
                string error = errors[0]["message"].ToString();
                throw new Exception(error);
            }
            return contentString;
        }


        public async Task<string> Mutation(string mutation)
        {
            mutation = string.Format("mutation{{ {0} }}", mutation);
            return await Request(mutation);
        }

        private async Task<string> Request(string requestString)
        {
            var response = await _client.GetAsync($"{GraphqlAddress}?query={requestString}");
            string contentString = await response.Content.ReadAsStringAsync();
            var errors = JObject.Parse(contentString)["errors"];
            if (errors != null)
            {
                string error = errors[0]["message"].ToString();
                throw new Exception(error);
            }
            return contentString;
        }
    }
}
