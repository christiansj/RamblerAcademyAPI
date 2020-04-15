using Newtonsoft.Json;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.Models;
using RamblerAcademyAPI.Util;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test.GraphQLTests
{
    [Collection("Course GraphQL Tests")]
    public class CourseGraphQLTests : GraphQLIntegrationTest<Course>
    {
        private readonly int _TestDataCnt;
        private readonly string fragment = "id courseNumber name subjectId";
        public CourseGraphQLTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Courses().Count;
        }

        [Fact]
        public async void CoursesQueryTest()
        {
            List<Course> courses = await ListQueryRequest($"courses{{{fragment}}}", "courses");

            AssertObjectsAreEqual(courses, TestData.Courses());
        }

        [Fact]
        public async void CourseQueryTest() 
        {
            const int courseId = 3;
            Course expectedCourse = TestData.Courses().Find(c => c.Id == courseId);
           

            Course course = await GetCourseAsync(courseId);

            AssertObjectsAreEqual(course, expectedCourse);
        }

        [Fact]
        public async void CourseCreateMutationTest()
        {
            Course expectedCourse = new Course(_TestDataCnt + 1, 300, "New English Course 3", 2);
            string mutation = $"createCourse(course: {CourseInput(expectedCourse)}){{{fragment}}}";

            var createTask = MutationRequest(mutation, "createCourse");
            createTask.Wait();


            AssertObjectsAreEqual(expectedCourse, createTask.Result);
            await AssertCourseCountAsync(_TestDataCnt + 1);
        }

        [Fact]
        public async void CourseUpdateMutationTest()
        {
            const int courseId = 2;
            Course expectedCourse = new Course(courseId, 100, "Updated New History Course", 3);
            string mutation = @$"updateCourse(courseId: {courseId}, course: {CourseInput(expectedCourse)})
                                {{{fragment}}}";

            var updateTask = MutationRequest(mutation, "updateCourse");
            updateTask.Wait();

            AssertObjectsAreEqual(expectedCourse, updateTask.Result);
            await AssertCourseCountAsync(_TestDataCnt);
        }

        [Fact]
        public async void CourseDeleteMutationTest()
        {
            const int courseId = 2;
            string mutation = $"mutation{{deleteCourse(courseId: {courseId})}}";

            var  deleteTask = GraphQLRequest(mutation, "deleteCourse");
            deleteTask.Wait();

            // course shouldn't be found in db
            string query = $"course(id: {courseId}){{{fragment}}}";

            Assert.Null(await GetCourseAsync(courseId));
            await AssertCourseCountAsync(_TestDataCnt - 1);
        }

        private async Task<Course> GetCourseAsync(int courseId)
        {
            string query = $"course(id: {courseId}){{{fragment}}}";
            return await SingleQueryRequest(query, "course");
        }
        private async Task AssertCourseCountAsync(int expectedCnt)
        {
            List<Course> courses = await ListQueryRequest($"courses{{{fragment}}}", "courses");
            Assert.Equal(expectedCnt, courses.Count);
        }

        private string CourseInput(Course course)
        {
            var fields = new CourseInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, course);
        }
    }
}
