using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class CourseSectionQuery : ObjectGraphType, IGraphQLQuery
    {
        public CourseSectionQuery(ICourseSectionRepository repository)
        {
            // courseSections
            Field<ListGraphType<CourseSectionType>>(
                "courseSections",
                resolve: context => repository.GetAll()
            );

            // courseSection(crn)
            Field<CourseSectionType>(
                "courseSection",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "crn" }
                ),
                resolve: context =>
                {
                    int courseSectionId = context.GetArgument<int>("crn");
                    return repository.GetCourseSectionByCrn(courseSectionId);
                }
            );
        }
    }
}
