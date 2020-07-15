using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using RamblerAcademyAPI.Data;
using RamblerAcademyAPI.GraphQL.GraphQlSchema;

using Microsoft.AspNetCore.Server.Kestrel.Core;
using RamblerAcademyAPI.Extensions;
using RamblerAcademyAPI.GraphQL.Client;
using System.Net.Http;

using Microsoft.OpenApi.Models;
namespace RamblerAcademyAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RamblerAcademyContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
 
            services.AddRespositoryServices();
            services.AddGraphQLQueryServices();
            services.AddGraphQLMutationServices();
            services.AddGraphQLConsumerServices();

            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped);
            services.AddHttpClient("graphQLClient", hc => { hc.BaseAddress = new System.Uri("https://localhost:5001/graphql"); });
            services.AddScoped<AppSchema>();
            services.AddScoped(x => new GraphQLClient(new HttpClient()));

            services.AddCors();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rambler Academy API", Version = "v1" });
            });


            services.Configure<KestrelServerOptions>(options => options.AllowSynchronousIO = true);
            services.Configure<IISServerOptions>(options => options.AllowSynchronousIO = true);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            
            app.UseGraphQLPlayground(options: new GraphQLPlaygroundOptions());
            app.UseGraphQL<AppSchema>();
            
            app.UseRouting();

            app.UseCors(
                options => options.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader()
            );

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rambler Academy API V1");
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
