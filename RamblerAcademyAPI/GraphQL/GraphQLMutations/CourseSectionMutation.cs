using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using RamblerAcademyAPI.Models;


namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class CourseSectionMutation : ObjectGraphType, IGraphQLMutation
    {
        public CourseSectionMutation(ICourseSectionRepository repository)
        {
            // createCourseSection(courseSection)
            Field<CourseSectionType>(
                "createCourseSection",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CourseSectionInputType>> { Name = "courseSection" }   
                ),
                resolve: context =>
                {
                    var courseSection = context.GetArgument<CourseSection>("courseSection");
                    return repository.CreateCourseSection(courseSection);
                }
            );

            // updateCourseSection(courseSection, crn)
            Field<CourseSectionType>(
                "updateCourseSection",
                arguments: new QueryArguments(
                     new QueryArgument<NonNullGraphType<CourseSectionInputType>> { Name = "courseSection" },
                     new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "crn" }
                ),
                resolve: context =>
                {
                    var crn = context.GetArgument<int>("crn");
                    var courseSection = context.GetArgument<CourseSection>("courseSection");

                    var dbCourseSection = repository.GetCourseSectionByCrn(crn);
                    if(dbCourseSection == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find CourseSection in the db"));
                        return null;
                    }
                    return repository.UpdateCourseSection(dbCourseSection, courseSection);
                }
            );

            // deleteCourseSection(crn)
            Field<StringGraphType>(
                "deleteCourseSection",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "crn" }
                ),
                resolve: context =>
                {
                    int crn = context.GetArgument<int>("crn");

                    var courseSection = repository.GetCourseSectionByCrn(crn);
                    if(courseSection == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find CourseSection in db."));
                        return null;
                    }

                    repository.DeleteCourseSection(courseSection);
                    return $"The CourseSection with the CRN {crn} has been succesffully deleted";

                }
            );
        }
    }
}
