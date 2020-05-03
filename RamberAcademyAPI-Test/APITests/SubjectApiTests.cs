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
    public class SubjectApiTests : AbstractApiTest<Subject>
    {
        private readonly int _TestDataCnt;
        protected readonly SubjectConsumer _consumer;

        public SubjectApiTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Subjects().Count;
            _consumer = new SubjectConsumer(_factory);
            _controller = new SubjectController(_consumer);
        }

        // GET /api/subject
        [Fact]
        public async void GET_SubjectsTest()
        {
            await API_GetAllRecordsTest(TestData.Subjects());
        }

        // GET /api/subject/{id}
        [Fact]
        public async void GET_SubjectTest()
        {
            const int subjectId = 2;
            var expected = TestData.Subjects().Find(s => s.Id == subjectId);

            await API_GetExistentRecordTest(subjectId, expected);
        }

        // GET /api/subject/{id}
        [Fact]
        public async void GET_NonExistentSubjectTest()
        {
            const int subjectId = 100000;

            var result = await _controller.Get(subjectId) as NotFoundResult;

            Assert.NotNull(result);
        }

        // POST /api/subject
        [Fact]
        public async void POST_SubjectTest()
        {
            var expected = new Subject(_TestDataCnt + 1, "New Test", "NEW");

            await API_PostRecordTest(_TestDataCnt, expected);
        }

        // PUT /api/subject/{id}
        [Fact]
        public async void PUT_SubjectTest()
        {
            const int subjectId = 2;
            var expected = new Subject(subjectId, "Updated Subject", "UPD");

            await API_PutRecordTest(subjectId, expected);
        }

        // PUT /api/subject/{id}
        [Fact]
        public async void PUT_NonExistentSubjectTest()
        {
            const int subjectId = 10000;
            var badSubject = new Subject(subjectId, "Bad Subject", "BAD");

            var result = await _controller.Put(subjectId, badSubject) as NotFoundResult;

            Assert.NotNull(result);
        }

        // DELETE /api/subject/{id}
        [Fact]
        public async void DELETE_SubjectTest()
        {
            await API_DeleteRecordTest(1);
        }

        // DELETE /api/subject/{id}
        [Fact]
        public async void DELETE_NonExistentSubjectTest()
        {
            const int subjectId = 10000;

            var result = await _controller.Delete(subjectId) as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}
