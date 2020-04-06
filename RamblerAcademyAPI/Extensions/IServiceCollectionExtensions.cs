using Microsoft.Extensions.DependencyInjection;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLMutations;
using RamblerAcademyAPI.GraphQL.GraphQLQueries;
using RamblerAcademyAPI.Repository;

namespace RamblerAcademyAPI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddRespositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IClassroomRepository, ClassroomRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
        }

        public static void AddGraphQLQueryServices(this IServiceCollection services)
        {
            services.AddScoped<IGraphQLQuery, BuildingQuery>();
            services.AddScoped<IGraphQLQuery, ClassroomQuery>();
            services.AddScoped<IGraphQLQuery, CourseQuery>();
            services.AddScoped<IGraphQLQuery, SubjectQuery>();
           
        }

        public static void AddGraphQLMutationServices(this IServiceCollection services)
        {
            services.AddScoped<IGraphQLMutation, BuildingMutation>();
            services.AddScoped<IGraphQLMutation, ClassroomMutation>();
            services.AddScoped<IGraphQLMutation, CourseMutation>();
            services.AddScoped<IGraphQLMutation, SubjectMutation>();
        }
    }
}
