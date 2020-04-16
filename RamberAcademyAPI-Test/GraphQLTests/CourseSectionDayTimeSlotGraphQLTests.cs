using Newtonsoft.Json;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.Models;
using RamblerAcademyAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace RamberAcademyAPI_Test.GraphQLTests
{
    public class CourseSectionDayTimeSlotGraphQLTests : GraphQLIntegrationTest<CourseSectionDayTimeSlot>
    {
        private readonly int _TestDataCnt;
        private readonly string fragment = "courseReferenceNumber dayId timeSlotId";

        public CourseSectionDayTimeSlotGraphQLTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.CourseSectionDayTimeSlots().Count;
        }

        private async Task<CourseSectionDayTimeSlot> GetRecordAsync(int crn, int dayId, int timeSlotId)
        {
            string query = $"courseSectionDayTimeSlot(crn: {crn}, dayId: {dayId}, timeSlotId: {timeSlotId}){{{fragment}}}";

            return await SingleQueryRequest(query, "courseSectionDayTimeSlot");
        }

        [Fact]
        public async void CourseSectionDayTimeSlotsQueryTest()
        {
            List<CourseSectionDayTimeSlot> records = 
                   await ListQueryRequest($"courseSectionDayTimeSlots{{{fragment}}}", "courseSectionDayTimeSlots");

            AssertObjectsAreEqual(TestData.CourseSectionDayTimeSlots().OrderBy(csdt=>csdt.CourseReferenceNumber), records.OrderBy(csdt => csdt.CourseReferenceNumber));
        }

        [Fact]
        public async void CourseSectionDayTimeSlotQueryTest()
        {
            const int crn = 54758;
            const int dayId = 2;
            const int timeSlotId = 3;
            CourseSectionDayTimeSlot expectedRecord =
                TestData.CourseSectionDayTimeSlots().Find(csdts => csdts.CourseReferenceNumber == crn && csdts.DayId == dayId && csdts.TimeSlotId == timeSlotId);

            CourseSectionDayTimeSlot record = await GetRecordAsync(crn, dayId, timeSlotId);

            AssertObjectsAreEqual(expectedRecord, record);
        }

        [Fact]
        public async void  CourseSectionDayTimeSlotCreateMutationTest()
        {
            const int crn = 47593;
            const int dayId = 1;
            const int timeSlotId = 1;
            CourseSectionDayTimeSlot expectedRecord = new CourseSectionDayTimeSlot(crn, dayId, timeSlotId);
            string mutation = string.Format("createCourseSectionDayTimeSlot(courseSectionDayTimeSlot: {0}){{{1}}}",
                                    InputRecord(expectedRecord), fragment);

            var createTask = MutationRequest(mutation, "createCourseSectionDayTimeSlot");
            createTask.Wait();

            AssertObjectsAreEqual(expectedRecord, createTask.Result);
            AssertObjectsAreEqual(expectedRecord, await GetRecordAsync(crn, dayId, timeSlotId));
            await AssertRecordCount(_TestDataCnt + 1, "courseSectionDayTimeSlots", fragment);
        }

        [Fact]
        public async void CourseSectionDayTimeSlotDeleteMutationTest()
        {
            const int crn = 54758;
            const int dayId = 2;
            const int timeSlotId = 3;
            string mutation = $"mutation{{deleteCourseSectionDayTimeSlot(crn: {crn}, dayId: {dayId}, timeSlotId: {timeSlotId})}}";

            var deleteTask = GraphQLRequest(mutation, "deleteCourseSectionDayTimeSlot");
            deleteTask.Wait();

            Assert.Null(await GetRecordAsync(crn, dayId, timeSlotId));
            await AssertRecordCount(_TestDataCnt - 1, "courseSectionDayTimeSlots", fragment);

        }

        private string InputRecord(CourseSectionDayTimeSlot record)
        {
            var fields = new CourseSectionDayTimeSlotInputType().Fields;

            return GraphQLQueryUtil.InputObject(fields, record);
        }
    }
}
