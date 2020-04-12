using Microsoft.Extensions.DependencyInjection;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLMutations;
using RamblerAcademyAPI.GraphQL.GraphQLQueries;
using RamblerAcademyAPI.Repository;
using GraphQL.Client;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers.Util;

namespace RamblerAcademyAPI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddRespositoryServices(this IServiceCollection services)
        {
            services.AddTransient<IBuildingRepository, BuildingRepository>();
            services.AddTransient<IClassroomRepository, ClassroomRepository>();
            services.AddTransient<ICourseRepository, CourseRepository>();
            services.AddTransient<ICourseSectionDayTimeSlotRepository, CourseSectionDayTimeSlotRepository>();
            services.AddTransient<ICourseSectionRepository, CourseSectionRepository>();
            services.AddTransient<IDayRepository, DayRepository>();
            services.AddTransient<IDayTimeSlotRepository, DayTimeSlotRepository>();
            services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<ISeasonRepository, SeasonRepository>();
            services.AddTransient<ISemesterRepository, SemesterRepository>();
            services.AddTransient<ISubjectRepository, SubjectRepository>();
            services.AddTransient<ITimeSlotRepository, TimeSlotRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public static void AddGraphQLQueryServices(this IServiceCollection services)
        {
            services.AddScoped<IGraphQLQuery, BuildingQuery>();
            services.AddScoped<IGraphQLQuery, ClassroomQuery>();
            services.AddScoped<IGraphQLQuery, CourseQuery>();
            services.AddScoped<IGraphQLQuery, CourseSectionDayTimeSlotQuery>();
            services.AddScoped<IGraphQLQuery, CourseSectionQuery>();
            services.AddScoped<IGraphQLQuery, DayQuery>();
            services.AddScoped<IGraphQLQuery, DayTimeSlotQuery>();
            services.AddScoped<IGraphQLQuery, EnrollmentQuery>();
            services.AddScoped<IGraphQLQuery, RoleQuery>();
            services.AddScoped<IGraphQLQuery, SeasonQuery>();
            services.AddScoped<IGraphQLQuery, SemesterQuery>();
            services.AddScoped<IGraphQLQuery, SubjectQuery>();
            services.AddScoped<IGraphQLQuery, TimeSlotQuery>();
            services.AddScoped<IGraphQLQuery, UserQuery>();
        }

        public static void AddGraphQLMutationServices(this IServiceCollection services)
        {
            services.AddScoped<IGraphQLMutation, BuildingMutation>();
            services.AddScoped<IGraphQLMutation, ClassroomMutation>();
            services.AddScoped<IGraphQLMutation, CourseMutation>();
            services.AddScoped<IGraphQLMutation, CourseSectionMutation>();
            services.AddScoped<IGraphQLMutation, CourseSectionDayTimeSlotMutation>();
            services.AddScoped<IGraphQLMutation, DayTimeSlotMutation>();
            services.AddScoped<IGraphQLMutation, EnrollmentMutation>();
            services.AddScoped<IGraphQLMutation, RoleMutation>();
            services.AddScoped<IGraphQLMutation, SeasonMutation>();
            services.AddScoped<IGraphQLMutation, SemesterMutation>();
            services.AddScoped<IGraphQLMutation, SubjectMutation>();
            services.AddScoped<IGraphQLMutation, TimeSlotMutation>();
            services.AddScoped<IGraphQLMutation, UserMutation>();
        }

        public static void AddGraphQLConsumerServices(this IServiceCollection services)
        {
            services.AddScoped<BuildingConsumer>();
            services.AddScoped<ClassroomConsumer>();
            services.AddScoped<CourseConsumer>();
            services.AddScoped<CourseSectionConsumer>();
            services.AddScoped<DayConsumer>();
            services.AddScoped<DayTimeSlotConsumer>();
            services.AddScoped<RoleConsumer>();
            services.AddScoped<SeasonConsumer>();
            services.AddScoped<SemesterConsumer>();
            services.AddScoped<SubjectConsumer>();
            services.AddScoped<TimeSlotConsumer>();
            services.AddScoped<UserConsumer>();
        }
    }
}
