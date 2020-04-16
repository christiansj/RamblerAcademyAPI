using Newtonsoft.Json;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.Models;
using RamblerAcademyAPI.Util;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test.GraphQLTests
{
    [Collection("Course Section GraphQL Tests")]
    public class CourseSectionGraphQLTests : GraphQLIntegrationTest<CourseSection>
    {
        private readonly int _TestDataCnt;
        private readonly string fragment = "courseReferenceNumber sectionNumber courseId semesterId classroomId";

        public CourseSectionGraphQLTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.CourseSections().Count;
        }

        // courseSections
        [Fact]
        public async void CourseSectionsQuery()
        {
            List<CourseSection> courseSections = await ListQueryRequest($"courseSections{{{fragment}}}", "courseSections");
            _output.WriteLine(_TestDataCnt.ToString());
        

            AssertObjectsAreEqual(TestData.CourseSections().OrderBy(cs=>cs.CourseReferenceNumber), courseSections.OrderBy(cs=>cs.CourseReferenceNumber));
        }

        // courseSection(crn)
        [Fact]
        public async void CourseSectionQuery()
        {
            const int crn = 57894;
            CourseSection ExpectedCourseSection = TestData.CourseSections().Find(cs => cs.CourseReferenceNumber == crn);

            CourseSection CourseSection = await GetCourseSectionAsync(crn);

            AssertObjectsAreEqual(ExpectedCourseSection, CourseSection);
        }

        [Fact]
        public async void CourseSectionCreateMutation()
        {
            CourseSection ExpectedCourseSection = new CourseSection(57849, 2, 1, 1, 1);
            string mutation = string.Format(@"createCourseSection(courseSection: {0}){{{1}}}",
                                    CourseSectionInput(ExpectedCourseSection), fragment);

            var createTask = MutationRequest(mutation, "createCourseSection");
            createTask.Wait();

            AssertObjectsAreEqual(ExpectedCourseSection, createTask.Result);
            await AssertRecordCount(_TestDataCnt + 1, "courseSections", fragment);
        }

        // updateCourseSection(crn, courseSection)
        [Fact]
        public async void CourseSectionUpdateMutation()
        {
            const int crn = 57894;
            CourseSection ExpectedCourseSection = new CourseSection(crn, 3, 2, 2, 3);
            string mutation = string.Format(@"updateCourseSection(crn: {0}, courseSection: {1}){{{2}}}",
                                    crn, CourseSectionInput(ExpectedCourseSection), fragment);

            CourseSection NewCourseSection = await MutationRequest(mutation, "updateCourseSection");


            AssertObjectsAreEqual(ExpectedCourseSection, NewCourseSection);
        }

        // deleteCourseSection(crn)
        [Fact]
        public async void CourseSectionDeleteMutation()
        {
            const int crn = 47593;
            string mutation = $"mutation{{deleteCourseSection(crn: {crn})}}";

            var deleteTask = GraphQLRequest(mutation, "deleteCourseSection");
            deleteTask.Wait();

            await AssertRecordCount(_TestDataCnt - 1, "courseSections", fragment);
            Assert.Null(await GetCourseSectionAsync(crn));
        }

        private async Task<CourseSection> GetCourseSectionAsync(int crn)
        {
            string query = $"courseSection(crn: {crn}){{{fragment}}}";

            return await SingleQueryRequest(query, "courseSection");
        }

        private string CourseSectionInput(CourseSection courseSection)
        {
            var fields = new CourseSectionInputType().Fields;

            return GraphQLQueryUtil.InputObject(fields, courseSection);
        }
    }
}
