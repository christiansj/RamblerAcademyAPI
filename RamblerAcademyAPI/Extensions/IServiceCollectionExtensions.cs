using Microsoft.Extensions.DependencyInjection;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLMutations;
using RamblerAcademyAPI.GraphQL.GraphQLQueries;
using RamblerAcademyAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddRespositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IClassroomRepository, ClassroomRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
        }

        public static void AddGraphQLQueryServices(this IServiceCollection services)
        {
            services.AddScoped<IGraphQLQuery, BuildingQuery>();
            services.AddScoped<IGraphQLQuery, ClassroomQuery>();
            services.AddScoped<IGraphQLQuery, SubjectQuery>();
           
        }

        public static void AddGraphQLMutationServices(this IServiceCollection services)
        {
            services.AddScoped<IGraphQLMutation, BuildingMutation>();
            services.AddScoped<IGraphQLMutation, SubjectMutation>();
        }
    }
}
