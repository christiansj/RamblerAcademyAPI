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

        // GET /api/course
        [Fact]
        public async void GET_CoursesTest()
        {
            await API_GetAllRecordsTest(TestData.Courses());
        }

        // GET /api/course/{id}
        [Fact]
        public async void GET_CourseTest()
        {
            const int id = 2;
            var expected = TestData.Courses().Find(c => c.Id == id);

            await API_GetExistentRecordTest(id, expected);
        }

        // GET /api/course/{id}
        [Fact]
        public async void GET_NonExistentCourseTest()
        {
            const int id = 10000;

            var result = await _controller.Get(id) as NotFoundResult;

            Assert.NotNull(result);
        }

        // POST /api/course
        [Fact]
        public async void POST_CourseTest()
        {
            var expected = new Course(_TestDataCnt + 1, 400, "POST Test Course", 1);

            await API_PostRecordTest(_TestDataCnt, expected);
        }

        // PUT /api/course/{id}
        [Fact]
        public async void PUT_CourseTest()
        {
            const int courseId = 3;
            var expected = new Course(courseId, 500, "Updated Test Course", 2);

            await API_PutRecordTest(courseId, expected);
        }

        // PUT /api/course/{id}
        [Fact]
        public async void PUT_NonExistentCourseTest()
        {
            const int courseId = 10000;
            Course badCourse = new Course(courseId, 420, "Bad Course", 1);
            var result = await _controller.Put(courseId, badCourse) as NotFoundResult;

            Assert.NotNull(result);
        }

        // DELETE /api/course/{id}
        [Fact]
        public async void DELETE_CourseTest()
        {
            await API_DeleteRecordTest(2);
        }

        // DELETE /api/course/{id}
        [Fact]
        public async void DELETE_NonExistentCourseTest()
        {
            const int courseId = 10000;

            var result = await _controller.Delete(courseId) as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}
