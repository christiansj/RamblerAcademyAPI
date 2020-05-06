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
    public class DayTimeSlotApiTests  : ApiTest<DayTimeSlot>
    {
        private readonly int _TestDataCnt;
        private readonly DayTimeSlotConsumer _consumer;
        private readonly DayTimeSlotController dayTimeSlotController;

        public DayTimeSlotApiTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Buildings().Count;
            _consumer = new DayTimeSlotConsumer(_factory);
            dayTimeSlotController = new DayTimeSlotController(_consumer);
        }

        // GET /api/dayTimeSlot/day/{dayId}
        [Fact]
        public async void GET_DayTimeSlotsPerDayTest()
        {
            const int dayId = 2;
            var expected = TestData.DayTimeSlots()
                .Where(dts=>dts.DayId == dayId)
                .ToList();

            var result = await dayTimeSlotController.GetPerDay(dayId) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (IEnumerable<DayTimeSlot>)result.Value;

            Assert.NotNull(actual);
            AssertListsAreEqual(expected, actual);
        }

        // GET /api/dayTimeSlot/timeSlot/{timeSlotId}
        [Fact]
        public async void GET_DayTimeSlotsPerTimeSlotTest()
        {
            const int timeSlotId = 1;
            var expected = TestData.DayTimeSlots()
                .Where(dts => dts.TimeSlotId == timeSlotId)
                .ToList();

            var result = await dayTimeSlotController.GetPerTimeSlot(timeSlotId) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (IEnumerable<DayTimeSlot>)result.Value;

            Assert.NotNull(actual);
            AssertListsAreEqual(expected, actual);
        }

        // GET /api/dayTimeSlot/day/{dayId}/timeSlot/{timeSlotId}
        [Fact]
        public async void GET_DayTimeSlotByIdsTest()
        {
            const int dayId = 3;
            const int timeSlotId = 2;
            var expected = TestData.DayTimeSlots()
                .FirstOrDefault(dts => dts.DayId == dayId && dts.TimeSlotId == timeSlotId);

            var actual = await GetDayTimeSlotAsync(dayId, timeSlotId);

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
        }

        // POST /api/dayTimeSlot
        [Fact]
        public async void POST_DayTimeSlotTest()
        {
            const int dayId = 1;
            const int timeSlotId = 2;
            var expected = new DayTimeSlot(dayId, timeSlotId);

            var result = await dayTimeSlotController.Post(expected) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (DayTimeSlot)result.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetDayTimeSlotAsync(dayId, timeSlotId));
        }

        // DELETE /api/dayTimeSlot/day/{dayId}/timeSlot/{timeSlotId}
        [Fact]
        public async void DELETE_DayTimeSlotTest()
        {
            const int dayId = 3;
            const int timeSlotId = 2;

            var deleteResult = await dayTimeSlotController.Delete(dayId, timeSlotId) as OkResult;
            var getResult = await dayTimeSlotController.GetByIds(dayId, timeSlotId) as NotFoundResult;

            Assert.NotNull(deleteResult);
            Assert.NotNull(getResult);
        }

        // DELETE /api/dayTimeSlot/day/{dayId}/timeSlot/{timeSlotId}
        [Fact]
        public async void DELETE_NonExistentDayTimeSlotTest()
        {
            const int dayId = 100000;
            const int timeSlotId = 200000;

            var result = await dayTimeSlotController.Delete(dayId, timeSlotId) as NotFoundResult;

            Assert.NotNull(result);
        }

        private async Task<DayTimeSlot> GetDayTimeSlotAsync(int dayId, int timeSlotId)
        {
            var result = await dayTimeSlotController.GetByIds(dayId, timeSlotId) as OkObjectResult;

            Assert.NotNull(result);

            return (DayTimeSlot)result.Value;
        }
    }
}
