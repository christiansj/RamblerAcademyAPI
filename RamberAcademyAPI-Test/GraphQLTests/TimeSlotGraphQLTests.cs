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
    [Collection("TimeSlot GraphQL Tests")]
    public class TimeSlotGraphQLTests : GraphQLIntegrationTest<TimeSlot>
    {
        private readonly int _TestDataCnt;
        private readonly string fragment = "id startTime endTime";

        public TimeSlotGraphQLTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.TimeSlots().Count;
        }

        [Fact]
        public async void TimeSlotsQueryTest()
        {
            List<TimeSlot> timeSlots = await ListQueryRequest($"timeSlots{{{fragment}}}", "timeSlots");

            AssertObjectsAreEqual(TestData.TimeSlots(), timeSlots);
        }

        [Fact]
        public async void TimeSlotQueryTest()
        {
            const int timeSlotId = 1;
            TimeSlot expectedTimeSlot = TestData.TimeSlots().Find(ts => ts.Id == timeSlotId);

            TimeSlot timeSlot = await GetTimeSlotAsync(timeSlotId);

            AssertObjectsAreEqual(expectedTimeSlot, timeSlot);
        }

        [Fact]
        public async void TimeSlotCreateMutationTest()
        {
            TimeSlot expectedTimeSlot = new TimeSlot(4, new TimeSpan(13, 0, 0), new TimeSpan(14, 15, 0));
            string mutation = $"createTimeSlot(timeSlot: {TimeSlotInput(expectedTimeSlot)}){{{fragment}}}";

            var createTask = MutationRequest(mutation, "createTimeSlot");
            createTask.Wait();

            AssertObjectsAreEqual(expectedTimeSlot, createTask.Result);
            AssertObjectsAreEqual(expectedTimeSlot, await GetTimeSlotAsync(expectedTimeSlot.Id));
            await AssertRecordCount(_TestDataCnt + 1, "timeSlots", fragment);
        }

        [Fact]
        public async void TimeSlotUpdateMutationTest()
        {
            const int timeSlotId = 1;
            TimeSlot expectedTimeSlot = new TimeSlot(timeSlotId, new TimeSpan(8, 0, 0), new TimeSpan(9, 45, 0));
            string mutation = $"updateTimeSlot(timeSlotId: {timeSlotId}, timeSlot: {TimeSlotInput(expectedTimeSlot)}){{{fragment}}}";

            TimeSlot newTimeSlot = await MutationRequest(mutation, "updateTimeSlot");

            AssertObjectsAreEqual(expectedTimeSlot, newTimeSlot);
            AssertObjectsAreEqual(expectedTimeSlot, await GetTimeSlotAsync(timeSlotId));
        }

        [Fact]
        public async void TimeSlotDeleteMutationTest()
        {
            const int timeSlotId = 3;
            string mutation = $"mutation{{deleteTimeSlot(timeSlotId: {timeSlotId})}}";

            var deleteTask = GraphQLRequest(mutation, "deleteTimeSlot");
            deleteTask.Wait();

            await AssertRecordCount(_TestDataCnt - 1, "timeSlots", fragment);
            Assert.Null(await GetTimeSlotAsync(timeSlotId));
        }

        private async Task<TimeSlot> GetTimeSlotAsync(int timeSlotId)
        {
            string query = $"timeSlot(id: {timeSlotId}){{{fragment}}}";

            return await SingleQueryRequest(query, "timeSlot");
        }

        private string TimeSlotInput(TimeSlot timeSlot)
        {
            var fields = new TimeSlotInputType().Fields;

            return GraphQLQueryUtil.InputObject(fields, timeSlot);
        }
    }
}
