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
    public class DayApiTests : AbstractOneIdApiTest<Day>
    {
        protected readonly DayConsumer _consumer;
        protected readonly DayController dayController;

        public DayApiTests(ITestOutputHelper output) : base(output)
        {
            _consumer = new DayConsumer(_factory);
            dayController = new DayController(_consumer);
        }

        // GET /api/day
        [Fact]
        public async void GET_DaysTest()
        {
            var expected = TestData.Days();

            var result = await dayController.Get() as OkObjectResult;
            Assert.NotNull(result);

            var actual = (IEnumerable<Day>)result.Value;

            Assert.NotNull(actual);
            AssertListsAreEqual(expected, actual);
        }

        // GET /api/day/{id}
        [Fact]
        public async void GET_DayTest()
        {
            const int dayId = 2;
            var expected = TestData.Days().Find(d => d.Id == dayId);

            var result = await dayController.Get(dayId) as OkObjectResult;
            Assert.NotNull(result);
            var actual = (Day)result.Value;

            Assert.NotNull(actual);
            AssertObjectsAreEqual(expected, actual);
        }

        // GET /api/day/{id}
        [Fact]
        public async void GET_NonExistentDayTest()
        {
            const int dayId = 10000;

            var result = await dayController.Get(dayId) as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}
