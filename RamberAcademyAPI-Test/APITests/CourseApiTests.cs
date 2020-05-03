using Microsoft.AspNetCore.Mvc;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.Controllers;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers;

using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test.APITests
{
    public class CourseApiTests : AbstractApiTest<Course>
    {
        private readonly int _TestDataCnt;
        protected readonly CourseConsumer _consumer;

        public CourseApiTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Courses().Count;
            _consumer = new CourseConsumer(_factory);
            _controller = new CourseController(_consumer);
        }

        [Fact]
        // GET /api/course
        public async void GET_CoursesTest()
        {
            await API_GetAllRecordsTest(TestData.Courses());
        }

        [Fact]
        // GET /api/course/{id}
        public async void GET_CourseTest()
        {
            const int id = 2;
            var expected = TestData.Courses().Find(c => c.Id == id);

            await API_GetExistentRecordTest(id, expected);
        }

        [Fact]
        // GET /api/course/{id}
        public async void GET_NonExistentCourseTest()
        {
            const int id = 10000;

            var result = await _controller.Get(id) as NotFoundResult;

            Assert.NotNull(result);
        }

        [Fact]
        // POST /api/course
        public async void POST_CourseTest()
        {
            var expected = new Course(_TestDataCnt + 1, 400, "POST Test Course", 1);

            await API_PostRecordTest(_TestDataCnt, expected);
        }

        [Fact]
        // PUT /api/course/{id}
        public async void PUT_CourseTest()
        {
            const int courseId = 3;
            var expected = new Course(courseId, 500, "Updated Test Course", 2);

            var result = await _controller.Put(courseId, expected) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (Course)result.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentRecordAsync(courseId));
        }

        [Fact]
        // PUT /api/course/{id}
        public async void PUT_NonExistentCourseTest()
        {
            const int courseId = 10000;
            Course badCourse = new Course(courseId, 420, "Bad Course", 1);
            var result = await _controller.Put(courseId, badCourse) as NotFoundResult;

            Assert.NotNull(result);
        }

        [Fact]
        // DELETE /api/course/{id}
        public async void DELETE_CourseTest()
        {
            const int courseId = 2;

            var deleteResult = await _controller.Delete(courseId) as OkResult;
            var getResult = await _controller.Get(courseId) as NotFoundResult;

            Assert.NotNull(deleteResult);
            Assert.NotNull(getResult);
        }

        [Fact]
        // DELETE /api/course/{id}
        public async void DELETE_NonExistentCourseTest()
        {
            const int courseId = 10000;

            var result = await _controller.Delete(courseId) as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}
