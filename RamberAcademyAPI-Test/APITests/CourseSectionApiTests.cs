using Microsoft.AspNetCore.Mvc;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.Controllers;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test.APITests
{
    public class CourseSectionApiTests : AbstractOneIdApiTest<CourseSection>
    {
        private readonly CourseSectionConsumer _consumer;

        public CourseSectionApiTests(ITestOutputHelper output) : base(output)
        {
            _consumer = new CourseSectionConsumer(_factory);
            _controller = new CourseSectionController(_consumer);
        }

        // GET /api/courseSection
        [Fact]
        public async void GET_CourseSectionsTest()
        {
            var expected = TestData.CourseSections().OrderBy(cs => cs.CourseReferenceNumber);

            var result = await _controller.Get() as OkObjectResult;
            Assert.NotNull(result);
            var actual = (IEnumerable<CourseSection>)result.Value;
            actual = actual.OrderBy(cs => cs.CourseReferenceNumber);

            AssertListsAreEqual(expected, actual);
        }

        // GET /api/courseSection/{crn}
        [Fact]
        public async void GET_CourseSectionTest()
        {
            const int crn = 47593;
            var expected = TestData.CourseSections().Find(cs => cs.CourseReferenceNumber == crn);

            await API_GetExistentRecordTest(crn, expected);
        }

        // GET /api/courseSection/{crn}
        [Fact]
        public async void GET_NonExistentCourseSectionTest()
        {
            const int crn = 1;

            var result = await _controller.Get(crn) as NotFoundResult;

            Assert.NotNull(result);
        }

        // POST /api/courseSection/{crn}
        [Fact]
        public async void POST_CourseSectionTest()
        {
            const int crn = 34874;
            var expected = new CourseSection(crn, 1, 1, 1, 2);

            var result = await _controller.Post(expected) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (CourseSection)result.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentRecordAsync(crn));
        }

        // PUT /api/courseSection/{crn}
        [Fact]
        public async void PUT_CourseSectionTest()
        {
            const int crn = 57894;
            var expected = new CourseSection(crn, 1, 1, 2, 3);

            await API_PutRecordTest(crn, expected);
        }

        // PUT /api/courseSection/{crn}
        [Fact]
        public async void PUT_NonExistentCourseSectionTest()
        {
            const int crn = 1000000;
            var badCourseSection = new CourseSection(crn, 1, 3, 1, 1);

            var result = await _controller.Put(crn, badCourseSection);

            Assert.NotNull(result);
        }

        // DELETE /api/courseSection/{crn}
        [Fact]
        public async void DELETE_CourseSection()
        {
            await API_DeleteRecordTest(57894);
        }

        // DELETE /api/courseSection/{crn}
        [Fact]
        public async void DELETE_NonExistentCourseSection()
        {
            const int crn = 42069;

            var result = await _controller.Delete(crn) as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}
