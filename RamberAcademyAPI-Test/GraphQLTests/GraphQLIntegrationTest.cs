
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

namespace RamberAcademyAPI_Test
{
    public class GraphQLIntegrationTest<T>
    {
        protected HttpClient _client;
        
        protected GraphQLIntegrationTest()
        {

            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    //builder.UseUrls("http://localhost:8000/");
                    builder.UseEnvironment("Test");
                    builder.ConfigureServices(services =>
                    {
                        var descriptor = services.SingleOrDefault(
                            d=> d.ServiceType == typeof(DbContextOptions<RamblerAcademyContext>));
                        if(descriptor != null && descriptor.ServiceType == typeof(DbContextOptions<RamblerAcademyContext>))
                        {
                            services.Remove(descriptor);
                        }
                        else
                        {
                            throw new Exception("couldn't find db context");
                        }
                        
                        services.AddDbContext<RamblerAcademyContext>(options => { options.UseInMemoryDatabase("testDb"); });
                       
                        var sp = services.BuildServiceProvider();

                        using (var scope = sp.CreateScope())
                        {
                            var scopedServices = scope.ServiceProvider;
                            var db = scopedServices.GetRequiredService<RamblerAcademyContext>();
                            var logger = scopedServices.GetRequiredService<ILogger<WebApplicationFactory<Startup>>>();
                            db.Database.EnsureCreated();

                            try
                            {
                                Utilities.IntializeDbForTests(db);
                            } catch (Exception ex)
                            {
                                logger.LogError(ex, "An Error ocurred seeding the the" +
                                    "database with test messages. Error: {Message}", ex.Message);
                            }
                        }
                    });
                    //
                });

           _client = appFactory.CreateClient(new WebApplicationFactoryClientOptions
           {
               AllowAutoRedirect = false
           });
            
        }   

        protected async Task<T> SingleQueryRequest(string query, string queryName)
        {
            var response = await _client.GetAsync($"/graphql?query={{{query}}}");
            string data = await ParseData(response, queryName);
            return JsonConvert.DeserializeObject<T>(data);
        }

        protected async Task<List<T>> ListQueryRequest(string query, string queryName)
        {
            var response = await _client.GetAsync($"/graphql?query={{{query}}}");
            string data = await ParseData(response, queryName);
            return JsonConvert.DeserializeObject<List<T>>(data);
        }

        protected async Task<string> MutationRequest(string mutation, string mutationName)
        {
            var response = await _client.GetAsync($"/graphql?query=mutation{{{mutation}}}");
            return await ParseData(response, mutationName);
        }

        protected async Task<string> ParseData(HttpResponseMessage message, string requestName)
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

        protected static void AssertObjectsAreEqual(object obj1, object obj2)
        {
            Assert.Equal(JsonConvert.SerializeObject(obj1), JsonConvert.SerializeObject(obj2));
        }
    }
}
