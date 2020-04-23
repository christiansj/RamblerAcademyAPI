﻿using Microsoft.AspNetCore.Mvc;
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
    public class ClassroomApiTests : AbstractApiTest<Classroom>
    {
        private readonly int _TestDataCnt;
        private const string fragment = "id name";
        protected readonly ClassroomConsumer _consumer;
        protected readonly ClassroomController _controller;
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
            IEnumerable<Classroom> expected = TestData.Classrooms().OrderBy(c => c.Id);

            var response = await _controller.Get() as OkObjectResult;
            Assert.NotNull(response);
            var actual = (IEnumerable<Classroom>)response.Value;

            Assert.NotNull(actual);
            AssertListsAreEqual(expected, actual.OrderBy(c => c.Id));
        }

        // GET /api/classroom/{id}
        [Fact]
        public async void GET_ClassroomTest()
        {
            const int classroomId = 3;

            Classroom expected = TestData.Classrooms().Find(c => c.Id == classroomId);
            Classroom actual = await GetExistentClassroomAsync(classroomId);

            AssertObjectsAreEqual(expected, actual);
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

            var response = await _controller.Post(expected) as OkObjectResult;
            Assert.NotNull(response);

            var actual = (Classroom)response.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentClassroomAsync(_TestDataCnt + 1));
        }

        // PUT /api/classroom/{id}
        [Fact]
        public async void PUT_ClassroomTest()
        {
            const int classroomId = 2;
            Classroom expected = new Classroom(classroomId, 9, 24, 23, 2);

            var response = await _controller.Put(classroomId, expected) as OkObjectResult;
            Assert.NotNull(response);
            Classroom actual = (Classroom)response.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentClassroomAsync(classroomId));
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
            const int classroomId = 3;

            var deleteResponse = await _controller.Delete(classroomId) as OkResult;
            var getResponse = await _controller.Get(classroomId) as NotFoundResult;

            Assert.NotNull(deleteResponse);
            Assert.NotNull(getResponse);
        }

        // DELETE /api/classroom/{id}
        [Fact]
        public async void DELETE_NonExistentClassroomTest()
        {
            const int classroomId = 30000;

            var response = await _controller.Delete(classroomId) as NotFoundResult;

            Assert.NotNull(response);
        }

        private async Task<Classroom> GetExistentClassroomAsync(int id)
        {
            var response = await _controller.Get(id) as OkObjectResult;
            Assert.NotNull(response);

            return (Classroom)response.Value;
        }
    }
}