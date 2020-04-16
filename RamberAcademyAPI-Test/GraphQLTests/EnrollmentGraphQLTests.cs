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
    public class EnrollmentGraphQLTests : GraphQLIntegrationTest<Enrollment>
    {
        private readonly int _TestDataCnt;
        private readonly string fragment = "courseReferenceNumber studentId";
        public EnrollmentGraphQLTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Enrollments().Count;
        }

        [Fact]
        public async void EnrollmentsQueryTest()
        {
            List<Enrollment> enrollments = await ListQueryRequest($"enrollments{{{fragment}}}", "enrollments");

            AssertObjectsAreEqual(TestData.Enrollments().OrderBy(e=>e.CourseReferenceNumber), enrollments.OrderBy(e=>e.CourseReferenceNumber));
        }

        [Fact]
        public async void EnrollmentQueryTest()
        {
            int crn = 47593;
            long studentId = 1;
            Enrollment expectedEnrollment = TestData.Enrollments().Find(e => e.CourseReferenceNumber == crn && e.StudentId == studentId);

            Enrollment enrollment = await GetEnrollmentAsync(crn, studentId);

            AssertObjectsAreEqual(expectedEnrollment, enrollment);
        }

        [Fact]
        public async void EnrollmentCreateMutationTest()
        {
            const int crn = 57894;
            const long studentId = 2;
            Enrollment expectedEnrollment = new Enrollment(crn, studentId);
            string mutation = $"createEnrollment(enrollment: {EnrollmentInput(expectedEnrollment)}){{{fragment}}}";

            var createTask = MutationRequest(mutation, "createEnrollment");
            createTask.Wait();

            AssertObjectsAreEqual(expectedEnrollment, createTask.Result);
            AssertObjectsAreEqual(expectedEnrollment, await GetEnrollmentAsync(crn, studentId));
            await AssertRecordCount(_TestDataCnt + 1, "enrollments", fragment);
        }

        [Fact]
        public async void EnrollmentDeleteMutation()
        {
            const int crn = 54758;
            const long studentId = 2;
            string mutation = $"mutation{{deleteEnrollment(crn: {crn}, studentId: {studentId})}}";

            var deleteTask = GraphQLRequest(mutation, "deleteEnrollment");
            deleteTask.Wait();

            await AssertRecordCount(_TestDataCnt - 1, "enrollments", fragment);
            Assert.Null(await GetEnrollmentAsync(crn, studentId));
        }

        private async Task<Enrollment> GetEnrollmentAsync(int crn, long studentId)
        {
            string query = $"enrollment(crn: {crn}, studentId: {studentId}){{{fragment}}}";

            return await SingleQueryRequest(query, "enrollment");
        }

        private string EnrollmentInput(Enrollment enrollment)
        {
            var fields = new EnrollmentInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, enrollment);
        }
    }
}
