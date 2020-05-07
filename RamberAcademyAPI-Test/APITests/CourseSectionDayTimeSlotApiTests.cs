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
    public class CourseSectionDayTimeSlotApiTests : ApiTest<CourseSectionDayTimeSlot>
    {
        private CourseSectionDayTimeSlotConsumer _consumer;
        private CourseSectionDayTimeSlotController testController;

        public CourseSectionDayTimeSlotApiTests(ITestOutputHelper output) : base(output)
        {
            _consumer = new CourseSectionDayTimeSlotConsumer(_factory);
            testController = new CourseSectionDayTimeSlotController(_consumer);
        }

        // GET /api/courseSectionDayTimeSlot/courseSection/{crn}
        [Fact]
        public async void GET_CourseSectionDayTimeSlotPerCourseSection()
        {
            const int crn = 47593;
            var expected = TestData.CourseSectionDayTimeSlots()
                .Where(cs => cs.CourseReferenceNumber == crn)
                .ToList();

            var result = await testController.GetPerCourseSection(crn) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (IEnumerable<CourseSectionDayTimeSlot>)result.Value;

            Assert.NotNull(actual);
            AssertListsAreEqual(expected, actual);
        }

        // GET /api/courseSectionDayTimeSlot/day/{dayId}
        [Fact]
        public async void GET_CourseSectionDayTimeSlotPerDay()
        {
            const int dayId = 1;
            var expected = TestData.CourseSectionDayTimeSlots()
                .Where(cs => cs.DayId == dayId)
                .ToList();

            var result = await testController.GetPerDay(dayId) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (IEnumerable<CourseSectionDayTimeSlot>)result.Value;

            Assert.NotNull(actual);
            AssertListsAreEqual(expected, actual);
        }

        // GET /api/courseSectionDayTimeSlot/courseSection/{crn}/day/{dayId}/timeSlot/{timeSlotId}
        [Fact]
        public async void GET_CourseSectiondDayTimeSlotTest()
        {
            const int crn = 54758;
            const int dayId = 2;
            const int timeSlotId = 3;
            var expected = TestData.CourseSectionDayTimeSlots()
                .FirstOrDefault(cs => cs.CourseReferenceNumber == crn && cs.DayId == dayId && cs.TimeSlotId == timeSlotId);

            var actual = await GetRecordAsync(crn, dayId, timeSlotId);

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
        }

        // GET /api/courseSectionDayTimeSlot/courseSection/{crn}/day/{dayId}/timeSlot/{timeSlotId}
        [Fact]
        public async void GET_NonExistentCourseSectionDayTimeSlotTest()
        {
            const int crn = 10000;
            const int dayId = 20000;
            const int timeSlotId = 30000;

            var result = await testController.Get(crn, dayId, timeSlotId) as NotFoundResult;

            Assert.NotNull(result);
        }

        // POST /api/courseSectionDayTimeSlot/
        [Fact]
        public async void POST_CourseSectionDayTimeSlotTest()
        {
            const int crn = 54758;
            const int dayId = 1;
            const int timeSlotId = 1;
            var expected = new CourseSectionDayTimeSlot(crn, dayId, timeSlotId);

            var result = await testController.Post(expected) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (CourseSectionDayTimeSlot)result.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
            AssertObjectsAreEqual(expected, await GetRecordAsync(crn, dayId, timeSlotId));
        }

        // DELETE /api/courseSectionDayTimeSlot/courseSection/{crn}/day/{dayId}/timeSlot/{timeSlotId}
        [Fact]
        public async void DELETE_CourseSectionDayTimeSlotTest()
        {
            const int crn = 47593;
            const int dayId = 3;
            const int timeSlotId = 2;

            var deleteResult = await testController.Delete(crn, dayId, timeSlotId) as OkResult;
            var getResult = await testController.Get(crn, dayId, timeSlotId) as NotFoundResult;

            Assert.NotNull(deleteResult);
            Assert.NotNull(getResult);
        }

        // DELETE /api/courseSectionDayTimeSlot/courseSection/{crn}/day/{dayId}/timeSlot/{timeSlotId}
        [Fact]
        public async void DELETE_NonExistenetCourseSectionDayTimeSlotTest()
        {
            const int crn = 1;
            const int dayId = 1000;
            const int timeSlotId = 2000;

            var result = await testController.Delete(crn, dayId, timeSlotId) as NotFoundResult;

            Assert.NotNull(result);
        }

        private async Task<CourseSectionDayTimeSlot> GetRecordAsync(int crn, int dayId, int timeSlotId)
        {
            var result = await testController.Get(crn, dayId, timeSlotId) as OkObjectResult;

            Assert.NotNull(result);

            return (CourseSectionDayTimeSlot)result.Value;
        }
    }
}
