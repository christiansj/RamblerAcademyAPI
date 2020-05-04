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
    public class SemesterApiTests : AbstractOneIdApiTest<Semester>
    {
        private readonly int _TestDataCnt;
        private readonly SemesterConsumer _consumer;

        public SemesterApiTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Semesters().Count;
            _consumer = new SemesterConsumer(_factory);
            _controller = new SemesterController(_consumer);
        }

        // GET /api/semester
        [Fact]
        public async void GET_SemestersTest()
        {
            await API_GetAllRecordsTest(TestData.Semesters());
        }

        // GET /api/semester/{id}
        [Fact]
        public async void GET_SemesterTest()
        {
            const int semesterId = 2;
            var expected = TestData.Semesters().Find(s => s.Id == semesterId);

            await API_GetExistentRecordTest(semesterId, expected);
        }

        // GET /api/semester/{id}
        [Fact]
        public async void GET_NonExistentSemesterTest()
        {
            const int semesterId = 10000;

            var result = await _controller.Get(semesterId) as NotFoundResult;

            Assert.NotNull(result);
        }

        // POST /api/semester
        [Fact]
        public async void POST_SemesterTest()
        {
            Semester expected = new Semester(_TestDataCnt + 1, 2000, new DateTime(2000, 1, 10), new DateTime(2000, 5, 12), 1);

            _output.WriteLine($"new semesterId; {expected.Id} and cnt: {_TestDataCnt}");
            await API_PostRecordTest(_TestDataCnt, expected);
        }

        // PUT /api/semester/{id}
        [Fact]
        public async void PUT_SemesterTest()
        {
            const int semesterId = 3;
            Semester expected = new Semester(semesterId, 3000, new DateTime(3000, 8, 10), new DateTime(3000, 12, 15), 2);

            await API_PutRecordTest(semesterId, expected);
        }

        // PUT /api/semester/{id}
        [Fact]
        public async void PUT_NonExistentSemesterTest()
        {
            const int semesterId = 10000;
            Semester badSemester = new Semester(semesterId, 3000, new DateTime(3000, 8, 10), new DateTime(3000, 12, 15), 2);

            var result = await _controller.Put(semesterId, badSemester) as NotFoundResult;

            Assert.NotNull(result);
        }

        // DELETE /api/semester/{id}
        [Fact]
        public async void DELETE_SemesterTest()
        {
            await API_DeleteRecordTest(2);
        }

        // DELETE /api/semester/{id}
        [Fact]
        public async void DELETE_NonExistentSemesterTest()
        {
            const int semesterId = 10000;

            var result = await _controller.Delete(semesterId) as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}
