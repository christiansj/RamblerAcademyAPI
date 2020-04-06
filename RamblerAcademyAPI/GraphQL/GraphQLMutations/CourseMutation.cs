using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class CourseMutation : ObjectGraphType, IGraphQLMutation
    {
        public CourseMutation(ICourseRepository repository)
        {
            // createCourse(course)
            Field<CourseType>(
                "createCourse",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CourseInputType>> { Name = "course"}
                ),
                resolve: context =>
                {
                    var course = context.GetArgument<Course>("course");
                    return repository.CreateCourse(course);
                }
            );

            // updateCourse(course, courseId)
            Field<CourseType>(
                "updateCourse",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CourseInputType>> { Name = "course" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "courseId" }
                ),
                resolve: context =>
                {
                    var courseId = context.GetArgument<int>("courseId");
                    var course = context.GetArgument<Course>("course");

                    var dbCourse = repository.GetCourseById(courseId);
                    if(dbCourse == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find course in db"));
                        return null;
                    }

                    return repository.UpdateCourse(dbCourse, course);
                }
            );

            // deleteCourse(courseId)
            Field<StringGraphType>(
                "deleteCourse",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "courseId"}
                ),
                resolve: context =>
                {
                    int courseId = context.GetArgument<int>("courseId");
                    var course = repository.GetCourseById(courseId);

                    if(course == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find the course in the db"));
                        return null;
                    }

                    repository.DeleteCourse(course);
                    return $"The course with the id {courseId} has been successfully deleted";
                }
            );
        }
    }
}
