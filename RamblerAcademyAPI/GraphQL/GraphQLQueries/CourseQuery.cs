using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class CourseQuery : ObjectGraphType, IGraphQLQuery
    {
        public CourseQuery(ICourseRepository repository)
        {
            // courses
            Field<ListGraphType<CourseType>>(
                "courses",
                resolve: context => repository.GetAll()
            );

            // course(id)
            Field<CourseType>(
                "course",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id" }
                ),
                resolve: context=> repository.GetCourseById(context.GetArgument<int>("id"))
            );
        }
    }
}
