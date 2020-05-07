
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

namespace RamberAcademyAPI_Test
{
 
    public class ApplicationFactory<TStartup> 
        : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(
                           d => d.ServiceType == typeof(DbContextOptions<RamblerAcademyContext>));
                if (descriptor != null)
                { 
                    services.Remove(descriptor);
                }

                services.AddDbContext<RamblerAcademyContext>(options => { options.UseInMemoryDatabase("testDb"); });

                var sp = services.BuildServiceProvider();

                using var scope = sp.CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<RamblerAcademyContext>();
                var logger = scopedServices.GetRequiredService<ILogger<WebApplicationFactory<Startup>>>();

                db.Database.EnsureCreated();

                try
                {
                    Utilities.IntializeDbForTests(db);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex, "An Error ocurred seeding the the" +
                        "database with test messages. Error: {Message}", ex.Message);
                }
            });

        }


    }
}
