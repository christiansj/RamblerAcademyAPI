using Newtonsoft.Json;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.Models;
using RamblerAcademyAPI.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test.GraphQLTests
{
    [Collection("Semester GraphQL Tests")]
    public class SemesterGraphQLTests : GraphQLIntegrationTest<Semester>
    {

        private readonly int _TestDataCnt;
        private const string fragment = "id year startDate endDate seasonId";
        public SemesterGraphQLTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Semesters().Count;
        }


        // semesters
        [Fact]
        public async void SemestersQueryTest()
        {
            List<Semester> semesters = await ListQueryRequest($"semesters{{{fragment}}}", "semesters");

            AssertObjectsAreEqual(TestData.Semesters(), semesters);
        }

        // semester(id)
        [Fact]
        public async void SemesterQueryTest()
        {
            const int semesterId = 2;
            Semester expectedSemester = TestData.Semesters().Find(s => s.Id == semesterId);

            Semester semester = await GetSemesterAsync(semesterId);

            AssertObjectsAreEqual(expectedSemester, semester);
        }

        // createSemester(semester)
        [Fact]
        public async void SemesterCreateMutationTest()
        {
            Semester expectedSemester = new Semester(_TestDataCnt + 1, 2000, new DateTime(2000, 1, 10), new DateTime(2000, 5, 16), 1);
            string mutation = $@"createSemester(semester: {SemesterInput(expectedSemester)}){{{fragment}}}";

            var createTask = MutationRequest(mutation, "createSemester");
            createTask.Wait();


            await AssertSemesterCntAsync(_TestDataCnt + 1);
            AssertEqualSemesters(expectedSemester, await GetSemesterAsync(_TestDataCnt + 1));
            AssertEqualSemesters(expectedSemester, createTask.Result);
        }

        // updateSemester(semesterId, semester)
        [Fact]
        public async void SemesterUpdateMutationTest()
        {
            const int semesterId = 1;
            Semester expectedSemester = new Semester(semesterId, 2001, new DateTime(2001, 1, 10), new DateTime(2001, 5, 16), 1);
            string mutation = $@"updateSemester(semesterId: {semesterId}, semester: {SemesterInput(expectedSemester)}){{{fragment}}}";

            Semester newSemester = await MutationRequest(mutation, "updateSemester");

            AssertEqualSemesters(expectedSemester, newSemester);
           
        }

        [Fact]
        public async void SemesterDeleteMutationTest()
        {
            const int semesterId = 2;
            string mutation = $"mutation{{deleteSemester(semesterId : {semesterId})}}";

            var deleteTask = GraphQLRequest(mutation, "deleteSemester");
            deleteTask.Wait();

            await AssertSemesterCntAsync(_TestDataCnt - 1);
            Assert.Null(await GetSemesterAsync(semesterId));
        }
     
        private async Task<Semester> GetSemesterAsync(int semesterId)
        {
            string query = $"semester(id: {semesterId}){{{fragment}}}";

            return await SingleQueryRequest(query, "semester");
        }

        private string SemesterInput(Semester semester)
        {
            var fields = new SemesterInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, semester);
        }

        private void AssertEqualSemesters(Semester expectedSemester, Semester semester)
        {
            Assert.Equal(expectedSemester.Id, semester.Id);
            Assert.Equal(expectedSemester.Year, semester.Year);
            Assert.Equal(expectedSemester.StartDate, semester.StartDate);
            Assert.Equal(expectedSemester.EndDate, semester.EndDate);
        }

        private async Task AssertSemesterCntAsync(int expectedCnt)
        {
            List<Semester> semesters = await ListQueryRequest($"semesters{{{fragment}}}", "semesters");

            Assert.Equal(expectedCnt, semesters.Count);
        }
    }
}
