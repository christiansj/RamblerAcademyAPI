using Microsoft.AspNetCore.Mvc;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.Controllers;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test.APITests
{
    public class EnrollmentApiTests : ApiTest<Enrollment>
    {

        private readonly int _TestDataCnt;
        protected readonly EnrollmentConsumer _consumer;
        protected readonly EnrollmentController enrollmentController;

        public EnrollmentApiTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Enrollments().Count;
            _consumer = new EnrollmentConsumer(_factory);
            enrollmentController = new EnrollmentController(_consumer);
        }

        // /api/enrollment/student/{studentId}
        [Fact]
        public async void GET_EnrollmentsPerStudentTest()
        {
            const long studentId = 1;
            var expected = TestData.Enrollments()
                .Where(e => e.StudentId == studentId)
                .ToList()
                .OrderBy(e=>e.CourseReferenceNumber);

            var result = await enrollmentController.GetEnrollmentsPerStudent(studentId) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (IEnumerable<Enrollment>)result.Value;
            actual = actual.OrderBy(e => e.CourseReferenceNumber);

            Assert.NotNull(actual);
            AssertListsAreEqual(expected, actual);
        }

        // /api/enrollment/courseSection/{crn}
        [Fact]
        public async void GET_EnrollmentsPerCourseSectionTest()
        {
            const int crn = 54758;
            var expected = TestData.Enrollments()
                .Where(e => e.CourseReferenceNumber == crn)
                .ToList()
                .OrderBy(e=>e.StudentId);

            var result = await enrollmentController.GetEnrollmentsPerCourseSection(crn) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (IEnumerable<Enrollment>)result.Value;
            actual = actual.OrderBy(e => e.StudentId);

            Assert.NotNull(actual);
            AssertListsAreEqual(expected, actual);
        }

        // GET /api/enrollment/student/{studentId}/courseSection/{crn}
        [Fact]
        public async void GET_EnrollmentTest()
        {
            const long studentId = 1;
            const int crn = 47593;
            var expected = TestData.Enrollments()
                .FirstOrDefault(e => e.StudentId == studentId && e.CourseReferenceNumber == crn);

            var result = await enrollmentController.Get(studentId, crn) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (Enrollment)result.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
        }

        // GET /api/enrollment/student/{studentId}/courseSection/{crn}
        [Fact]
        public async void GET_NonExistentEnrollmentTest()
        {
            const long studentId = 100;
            const int crn = 1;

            var result = await enrollmentController.Get(studentId, crn) as NotFoundResult;
            
            Assert.NotNull(result);
        }

        // DELETE /api/enrollment/student/{studentId}/courseSection/{crn}
        [Fact]
        public async void DELETE_EnrollmentTest()
        {
            const long studentId = 1;
            const int crn = 57894;

            var deleteResult = await enrollmentController.Delete(studentId, crn) as OkResult;
            var getResult = await enrollmentController.Get(studentId, crn) as NotFoundResult;

            Assert.NotNull(deleteResult);
            Assert.NotNull(getResult);
        }

        // DELETE /api/enrollment/student/{studentId}/courseSection/{crn}
        [Fact]
        public async void DELETE_NonExistentEnrollmentTest()
        {
            const long studentId = 100000;
            const int crn = 2;

            var result = await enrollmentController.Delete(studentId, crn);

            Assert.NotNull(result);
        }

        private async Task<Enrollment> GetExistentEnrollmentAsync(long studentId, int crn)
        {
            var result = await enrollmentController.Get(studentId, crn) as OkObjectResult;

            Assert.NotNull(result);

            return (Enrollment)result.Value;
        }
    }
}
