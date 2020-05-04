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
    public class TimeSlotApiTests : AbstractOneIdApiTest<TimeSlot>
    {
        private readonly int _TestDataCnt;
        protected readonly TimeSlotConsumer _consumer;

        public TimeSlotApiTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.TimeSlots().Count;
            _consumer = new TimeSlotConsumer(_factory);
            _controller = new TimeSlotController(_consumer);
        }

        // GET /api/timeSlot
        [Fact]
        public async void GET_TimeSlotsTest()
        {
            await API_GetAllRecordsTest(TestData.TimeSlots());
        }
 
        // GET /api/timeSlot/{id}
        [Fact]
        public async void GET_TimeSlotTest()
        {
            const int timeSlotId = 3;
            var expected = TestData.TimeSlots().Find(ts => ts.Id == timeSlotId);

            await API_GetExistentRecordTest(timeSlotId, expected);
        }
       
         // GET /api/timeSlot/{id}
        [Fact]
        public async void GET_NonExistentTimeSlot()
        {
            const int timeSlotId = 100000;

            var result = await _controller.Get(timeSlotId) as NotFoundResult;

            Assert.NotNull(result);
        }

        // POST /api/timeSlot
        [Fact]
        public async void POST_TimeSlotTest()
        {
            var expected = new TimeSlot(_TestDataCnt + 1, new TimeSpan(3, 40, 0), new TimeSpan(4, 40, 0));

            await API_PostRecordTest(_TestDataCnt, expected);
        }

        // PUT /api/timeSlot/{id}
        [Fact]
        public async void PUT_TimeSlotTest()
        {
            const int timeSlotId = 3;
            var expected = new TimeSlot(timeSlotId, new TimeSpan(5, 20, 0), new TimeSpan(6, 0, 0));

            await API_PutRecordTest(timeSlotId, expected);
        }

        // PUT /api/timeSlot/{id}
        [Fact]
        public async void PUT_NonExistentTimeSlotTest()
        {
            const int timeSlotId = 10000;
            TimeSlot badTimeSlot = new TimeSlot(timeSlotId, new TimeSpan(6, 0, 0), new TimeSpan(16, 20, 0));

            var result = await _controller.Put(timeSlotId, badTimeSlot) as NotFoundResult;
            
            Assert.NotNull(result);
        }

        // DELETE /api/timeSlot/{id}
        [Fact]
        public async void DELETE_TimeSlotTest()
        {
            await API_DeleteRecordTest(2);
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
