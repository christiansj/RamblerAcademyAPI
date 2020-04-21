
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

namespace RamberAcademyAPI_Test
{
    class TestClientFactory
    {
        public static HttpClient CreateClient()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    //builder.UseUrls("http://localhost:8000/");
                    builder.UseEnvironment("Test");
                    builder.ConfigureServices(async services =>
                    {
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType == typeof(DbContextOptions<RamblerAcademyContext>));
                        if (descriptor != null && descriptor.ServiceType == typeof(DbContextOptions<RamblerAcademyContext>))
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
                                await Utilities.IntializeDbForTests(db);
                                await Utilities.AddMoreData(db);
                            }
                            catch (Exception ex)
                            {
                                logger.LogError(ex, "An Error ocurred seeding the the" +
                                    "database with test messages. Error: {Message}", ex.Message);
                            }
                        }
                    });
                });

            HttpClient client  = appFactory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });

            return client;
        }
    }
}
