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
            services.AddTransient<ICourseSectionRepository, CourseSectionRepository>();
            services.AddTransient<IDayRepository, DayRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISeasonRepository, SeasonRepository>();
            services.AddTransient<ISemesterRepository, SemesterRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void AddGraphQLQueryServices(this IServiceCollection services)
        {
            services.AddScoped<IGraphQLQuery, BuildingQuery>();
            services.AddScoped<IGraphQLQuery, ClassroomQuery>();
            services.AddScoped<IGraphQLQuery, CourseQuery>();
            services.AddScoped<IGraphQLQuery, CourseSectionQuery>();
            services.AddScoped<IGraphQLQuery, DayQuery>();
            services.AddScoped<IGraphQLQuery, RoleQuery>();
            services.AddScoped<IGraphQLQuery, SeasonQuery>();
            services.AddScoped<IGraphQLQuery, SemesterQuery>();
            services.AddScoped<IGraphQLQuery, SubjectQuery>();
            services.AddScoped<IGraphQLQuery, UserQuery>();
           
        }

        public static void AddGraphQLMutationServices(this IServiceCollection services)
        {
            services.AddScoped<IGraphQLMutation, BuildingMutation>();
            services.AddScoped<IGraphQLMutation, ClassroomMutation>();
            services.AddScoped<IGraphQLMutation, CourseMutation>();
            services.AddScoped<IGraphQLMutation, CourseSectionMutation>();
            services.AddScoped<IGraphQLMutation, RoleMutation>();
            services.AddScoped<IGraphQLMutation, SeasonMutation>();
            services.AddScoped<IGraphQLMutation, SemesterMutation>();
            services.AddScoped<IGraphQLMutation, SubjectMutation>();
            services.AddScoped<IGraphQLMutation, UserMutation>();
        }
    }
}
