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
    public class SeasonApiTests : AbstractApiTest<Season>
    {
        private readonly int _TestDataCnt;
        private readonly SeasonConsumer _consumer;

        public SeasonApiTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Seasons().Count;
            _consumer = new SeasonConsumer(_factory);
            _controller = new SeasonController(_consumer);
        }

        // GET /api/season
        [Fact]
        public async void GET_SeasonsTest()
        {
            await API_GetAllRecordsTest(TestData.Seasons());
        }

        // GET /api/season/{id}
        [Fact]
        public async void GET_SeasonTest()
        {
            const int seasonId = 1;
            var expected = TestData.Seasons().Find(s => s.Id == seasonId);

            await API_GetExistentRecordTest(seasonId, expected);
        }

        // GET /api/season/{id}
        [Fact]
        public async void GET_NonExistentSeasonTest()
        {
            const int seasonId = 10000;

            var result = await _controller.Get(seasonId) as NotFoundResult;

            Assert.NotNull(result);
        }

        // POST /api/season
        [Fact]
        public async void POST_SeasonTest()
        {
            Season expected = new Season(_TestDataCnt + 1, "New Test Season");

            await API_PostRecordTest(_TestDataCnt, expected);
        }

        // PUT /api/season/{id}
        [Fact]
        public async void PUT_SeasonTest()
        {
            const int seasonId = 2;
            Season expected = new Season(seasonId, "Updated Test Season");

            await API_PutRecordTest(seasonId, expected);
        }

        // PUT /api/season/{id}
        [Fact]
        public async void PUT_NonExistentSeasonTest()
        {
            const int seasonId = 10000;
            Season badSeason = new Season(seasonId, "Bad Test Season");

            var result = await _controller.Put(seasonId, badSeason) as NotFoundResult;

            Assert.NotNull(result);
        }

        // DELETE /api/season/{id}
        [Fact]
        public async void DELETE_SeasonTest()
        {
            await API_DeleteRecordTest(2);
        }

        // DELETE /api/season/{id}
        [Fact]
        public async void DELETE_NonExistentSeasonTest()
        {
            const int seasonId = 10000;

            var result = await _controller.Delete(seasonId) as NotFoundResult;

            Assert.NotNull(result);
        }
    }
}
