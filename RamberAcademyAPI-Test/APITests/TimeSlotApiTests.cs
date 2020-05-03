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
    public class TimeSlotApiTests : AbstractApiTest<TimeSlot>
    {
        private readonly int _TestDataCnt;
        protected readonly TimeSlotConsumer _consumer;

        public TimeSlotApiTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.TimeSlots().Count;
            _consumer = new TimeSlotConsumer(_factory);
            _controller = new TimeSlotController(_consumer);
        }

        [Fact]
        // GET /api/timeSlot
        public async void GET_TimeSlotsTest()
        {
            var expected = TestData.TimeSlots();

            var result = await _controller.Get() as OkObjectResult;
            Assert.NotNull(result);
            var actual = (IEnumerable<TimeSlot>)result.Value;

            Assert.NotNull(actual);
            AssertListsAreEqual(expected, actual);
        }

        [Fact]
        // GET /api/timeSlot/{id}
        public async void GET_TimeSlotTest()
        {
            const int timeSlotId = 3;
            var expected = TestData.TimeSlots().Find(ts => ts.Id == timeSlotId);

      
            var actual = await GetExistentRecordAsync(timeSlotId);

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
        }

        [Fact]
        // GET /api/timeSlot/{id}
        public async void GET_NonExistentTimeSlot()
        {
            const int timeSlotId = 100000;

            var result = await _controller.Get(timeSlotId) as NotFoundResult;

            Assert.NotNull(result);
        }

        [Fact]
        // POST /api/timeSlot
        public async void POST_TimeSlotTest()
        {
            var expected = new TimeSlot(_TestDataCnt + 1, new TimeSpan(3, 40, 0), new TimeSpan(4, 40, 0));

            var result = await _controller.Post(expected) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (TimeSlot)result.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentRecordAsync(_TestDataCnt + 1));
        }

        [Fact]
        // PUT /api/timeSlot/{id}
        public async void PUT_TimeSlotTest()
        {
            const int timeSlotId = 3;
            var expected = new TimeSlot(timeSlotId, new TimeSpan(5, 20, 0), new TimeSpan(6, 0, 0));

            var result = await _controller.Put(timeSlotId, expected) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (TimeSlot)result.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetExistentRecordAsync(timeSlotId));
        }

        [Fact]
        // PUT /api/timeSlot/{id}
        public async void PUT_NonExistentTimeSlotTest()
        {
            const int timeSlotId = 10000;
            TimeSlot badTimeSlot = new TimeSlot(timeSlotId, new TimeSpan(6, 0, 0), new TimeSpan(16, 20, 0));

            var result = await _controller.Put(timeSlotId, badTimeSlot) as NotFoundResult;
            
            Assert.NotNull(result);
        }

        [Fact]
        // DELETE /api/timeSlot/{id}
        public async void DELETE_TimeSlotTest()
        {
            const int timeSlotId = 2;

            var deleteResult = await _controller.Delete(timeSlotId) as OkResult;
            var getResult = await _controller.Get(timeSlotId) as NotFoundResult;

            Assert.NotNull(deleteResult);
            Assert.NotNull(getResult);
        }

        [Fact]
        // DELETE /api/timeSlot/{id}
        public async void DELETE_NonExistentTimeSlotTest()
        {
            const int timeSlotId = 10000;

            var result = await _controller.Delete(timeSlotId) as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}
