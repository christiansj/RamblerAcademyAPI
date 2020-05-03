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

        [Fact]
        // GET /api/subject
        public async void GET_SubjectsTest()
        {
            await GET_AllRecordsTest(TestData.Subjects());
        }

        [Fact]
        // GET /api/subject/{id}
        public async void GET_SubjectTest()
        {
            const int subjectId = 2;
            var expected = TestData.Subjects().Find(s => s.Id == subjectId);

            var actual = await GetExistentRecordAsync(subjectId);

            AssertObjectsAreEqual(expected, actual);
        }

        [Fact]
        // GET /api/subject/{id}
        public async void GET_NonExistentSubjectTest()
        {
            const int subjectId = 100000;

            var result = await _controller.Get(subjectId) as NotFoundResult;

            Assert.NotNull(result);
        }

        [Fact]
        // POST /api/subject
        public async void POST_SubjectTest()
        {
            var expected = new Subject(_TestDataCnt + 1, "New Test", "NEW");

            var result = await _controller.Post(expected) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (Subject)result.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentRecordAsync(_TestDataCnt + 1));
        }

        [Fact]
        // PUT /api/subject/{id}
        public async void PUT_SubjectTest()
        {
            const int subjectId = 2;
            var expected = new Subject(subjectId, "Updated Subject", "UPD");

            var result = await _controller.Put(subjectId, expected) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (Subject)result.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentRecordAsync(subjectId));
        }

        [Fact]
        // PUT /api/subject/{id}
        public async void PUT_NonExistentSubjectTest()
        {
            const int subjectId = 10000;
            var badSubject = new Subject(subjectId, "Bad Subject", "BAD");

            var result = await _controller.Put(subjectId, badSubject) as NotFoundResult;

            Assert.NotNull(result);
        }

        [Fact]
        // DELETE /api/subject/{id}
        public async void DELETE_SubjectTest()
        {
            const int subjectId = 1;

            var deleteResult = await _controller.Delete(subjectId) as OkResult;
            var getResult = await _controller.Get(subjectId) as NotFoundResult;

            Assert.NotNull(deleteResult);
            Assert.NotNull(getResult);
        }

        [Fact]
        // DELETE /api/subject/{id}
        public async void DELETE_NonExistentSubjectTest()
        {
            const int subjectId = 10000;

            var result = await _controller.Delete(subjectId) as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}
