using Newtonsoft.Json;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.Models;
using RamblerAcademyAPI.Util;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test.GraphQLTests
{
    [Collection("DayTimeSlot GraphQL Tests")]
    public class DayTimeSlotGraphQLTests : GraphQLIntegrationTest<DayTimeSlot>
    {
        private readonly int _TestDataCnt;
        private readonly string fragment = "dayId timeSlotId";

        public DayTimeSlotGraphQLTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.DayTimeSlots().Count;
        }

        [Fact]
        public async void DayTimeSlotsQueryTest()
        {
            List<DayTimeSlot> dayTimeSlots = await ListQueryRequest($"dayTimeSlots{{{fragment}}}", "dayTimeSlots");

            AssertObjectsAreEqual(TestData.DayTimeSlots().OrderBy(dts=>dts.DayId), dayTimeSlots.OrderBy(dts=>dts.DayId));
        }

        [Fact]
        public async void DayTimeSlotQueryTest()
        {
            const int dayId = 2;
            const int timeSlotId = 3;
            DayTimeSlot expectedDayTimeSlot = TestData.DayTimeSlots().Find(dts => dts.DayId == dayId && dts.TimeSlotId == timeSlotId);

            DayTimeSlot dayTimeSlot = await GetDayTimeSlotAsync(dayId, timeSlotId);

            AssertObjectsAreEqual(expectedDayTimeSlot, dayTimeSlot);
        }

        [Fact]
        public async void DayTimeSlotCreateMutationTest()
        {
            const int dayId = 2;
            const int timeSlotId = 2;
            DayTimeSlot expectedDayTimeSlot = new DayTimeSlot(dayId, timeSlotId);
            string mutation = $"createDayTimeSlot(dayTimeSlot: {DayTimeSlotInput(expectedDayTimeSlot)}){{{fragment}}}";

            var createTask = MutationRequest(mutation, "createDayTimeSlot");
            createTask.Wait();

            AssertObjectsAreEqual(expectedDayTimeSlot, createTask.Result);
            AssertObjectsAreEqual(expectedDayTimeSlot, await GetDayTimeSlotAsync(dayId, timeSlotId));
            await AssertRecordCount(_TestDataCnt + 1, "dayTimeSlots", fragment);
        }

        [Fact]
        public async void DayTimeSlotDeleteMutationTest()
        {
            const int dayId = 2;
            const int timeSlotId = 3;
            string mutation = $"mutation{{deleteDayTimeSlot(dayId: {dayId}, timeSlotId: {timeSlotId})}}";

            var deleteTask = GraphQLRequest(mutation, "deleteDayTimeSlot");
            deleteTask.Wait();

            await AssertRecordCount(_TestDataCnt - 1, "dayTimeSlots", fragment);
            Assert.Null(await GetDayTimeSlotAsync(dayId, timeSlotId));
        }

        private async Task<DayTimeSlot> GetDayTimeSlotAsync(int dayId, int timeSlotId)
        {
            string query = $"dayTimeSlot(dayId: {dayId}, timeSlotId: {timeSlotId}){{{fragment}}}";

            return await SingleQueryRequest(query, "dayTimeSlot");
        }

        private string DayTimeSlotInput(DayTimeSlot dayTimeSlot)
        {
            var fields = new DayTimeSlotInputType().Fields;

            return GraphQLQueryUtil.InputObject(fields, dayTimeSlot);
        }
    }
}
