
using RamblerAcademyAPI;
using System.Net.Http;

using Microsoft.AspNetCore.Mvc.Testing;

using Microsoft.Extensions.DependencyInjection.Extensions;
using RamblerAcademyAPI.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Google.Apis.Util;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Xunit.Abstractions;

[assembly: Xunit.CollectionBehavior(DisableTestParallelization = true)]
namespace RamberAcademyAPI_Test
{
   
    public class GraphQLIntegrationTest<T>
    {
        protected HttpClient _client;
        protected ITestOutputHelper _output;
        protected GraphQLIntegrationTest(ITestOutputHelper output)
        {
            _output = output;
            _client = TestClientFactory.CreateClient();
        }   

        protected async Task<T> SingleQueryRequest(string query, string queryName)
        {
            string data = await GraphQLRequest($"{{{query}}}", queryName);
            return JsonConvert.DeserializeObject<T>(data);
        }

        protected async Task<List<T>> ListQueryRequest(string query, string queryName)
        {
            string data = await GraphQLRequest($"{{{query}}}", queryName);
            return JsonConvert.DeserializeObject<List<T>>(data);
        }

        protected async Task<T> MutationRequest(string mutation, string mutationName)
        {
            string data = await GraphQLRequest($"mutation{{{mutation}}}", mutationName);
            return JsonConvert.DeserializeObject<T>(data);
        }

        protected async Task<string> GraphQLRequest(string requestString, string requestName)
        {
            var response = await _client.GetAsync($"/graphql?query={requestString}");
            string data = await ParseData(response, requestName);
            _output.WriteLine($"{requestName} results:\n{data}");
            return data;
        }
        private async Task<string> ParseData(HttpResponseMessage message, string requestName)
        {
            string contentString = await message.Content.ReadAsStringAsync();
            var errors = JObject.Parse(contentString)["errors"];
            if (errors != null)
            {
                string error = errors[0]["message"].ToString();
                Assert.True(false, error);
            }
            return JObject.Parse(contentString)["data"][requestName].ToString();
        }

        protected void AssertObjectsAreEqual(object obj1, object obj2)
        {
            Assert.Equal(JsonConvert.SerializeObject(obj1), JsonConvert.SerializeObject(obj2));
        }

        protected async Task AssertRecordCount(int expectedCount, string queryName, string fragment)
        {
            List<T> records = await ListQueryRequest($"{queryName}{{{fragment}}}", queryName);

            Assert.Equal(expectedCount, records.Count);
        }
    }
}
