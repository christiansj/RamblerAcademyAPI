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
    public class ClassroomApiTests : AbstractOneIdApiTest<Classroom>
    {
        private readonly int _TestDataCnt;
        protected readonly ClassroomConsumer _consumer;
        
        public ClassroomApiTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Classrooms().Count;
            _consumer = new ClassroomConsumer(_factory);
            _controller = new ClassroomController(_consumer);
        }

        // GET /api/classroom
        [Fact]
        public async void GET_ClassroomsTest()
        {
            await API_GetAllRecordsTest(TestData.Classrooms());
        }

        // GET /api/classroom/{id}
        [Fact]
        public async void GET_ClassroomTest()
        {
            const int classroomId = 3;
            Classroom expected = TestData.Classrooms().Find(c => c.Id == classroomId);

            await API_GetExistentRecordTest(classroomId, expected);
        }

        // GET /api/classroom/{id}
        [Fact]
        public async void GET_NonExistentClassroomTest()
        {
            const int classroomId = 10000;

            var response = await _controller.Get(classroomId) as NotFoundResult;

            Assert.NotNull(response);
        }

        // POST /api/classroom
        [Fact]
        public async void POST_ClassroomTest()
        {
            Classroom expected = new Classroom(_TestDataCnt + 1, 4, 5, 54, 2);

            await API_PostRecordTest(_TestDataCnt, expected);
        }

        // PUT /api/classroom/{id}
        [Fact]
        public async void PUT_ClassroomTest()
        {
            const int classroomId = 2;
            Classroom expected = new Classroom(classroomId, 9, 24, 23, 2);

            await API_PutRecordTest(classroomId, expected);
        }

        // PUT /api/classroom/{id}
        [Fact]
        public async void PUT_NonExistentClassroomTest()
        {
            const int classroomId = 10000;
            Classroom badClassroom = new Classroom(classroomId, 4, 3, 4, 2);

            var response = await _controller.Put(classroomId, badClassroom) as NotFoundResult;

            Assert.NotNull(response);
        }

        // DELETE /api/classroom/{id}
        [Fact]
        public async void DELETE_ClassroomTest()
        {
            await API_DeleteRecordTest(3);
        }

        // DELETE /api/classroom/{id}
        [Fact]
        public async void DELETE_NonExistentClassroomTest()
        {
            const int classroomId = 30000;

            var response = await _controller.Delete(classroomId) as NotFoundResult;

            Assert.NotNull(response);
        }
    }
}