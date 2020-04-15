using Newtonsoft.Json;
using RamberAcademyAPI_Test.Data;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.Models;
using RamblerAcademyAPI.Util;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;


namespace RamberAcademyAPI_Test.GraphQLTests
{
    [Collection("Season GraphQL Tests")]
    public class SeasonGraphQLTests : GraphQLIntegrationTest<Season>
    {
        private readonly int _TestDataCnt;
        private const string fragment = "id name";

        public SeasonGraphQLTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Seasons().Count;
        }

        [Fact]
        public async void SeasonsQueryTest()
        {
            List<Season> seasons = await ListQueryRequest($"seasons{{{fragment}}}", "seasons");

            AssertObjectsAreEqual(TestData.Seasons(), seasons);
        }

        [Fact]
        public async void SeasonQueryTest()
        {
            const int seasonId = 2;
            Season expectedSeason = TestData.Seasons().Find(s => s.Id == seasonId);

            Season season = await GetSeasonAsync(seasonId);

            AssertObjectsAreEqual(expectedSeason, season);
        }

        [Fact]
        public async void SeasonCreateMutationTest()
        {
            int expectedSeasonId = _TestDataCnt+1;
            Season expectedSeason = new Season(expectedSeasonId, "New Test Season");
            string mutation = $"createSeason(season: {SeasonInput(expectedSeason)}){{{fragment}}}";

            var createTask = MutationRequest(mutation, "createSeason");
            createTask.Wait();

            AssertObjectsAreEqual(expectedSeason, createTask.Result);
            AssertObjectsAreEqual(expectedSeason, await GetSeasonAsync(expectedSeasonId));
            await AssertSeasonCountAsync(expectedSeasonId);
        }

        [Fact]
        public async void SeasonUpdateMutationTest()
        {
            const int seasonId = 1;
            Season expectedSeason = new Season(seasonId, "Updated Test Season");
            string mutation = @$"updateSeason(seasonId: {seasonId}, season: {SeasonInput(expectedSeason)})
                                {{{fragment}}}";

            Season newSeason = await MutationRequest(mutation, "updateSeason");

            AssertObjectsAreEqual(expectedSeason, newSeason);
        }

        [Fact]
        public async void SeasonDeleteMutationTest()
        {
            const int seasonId = 1;
            string mutation = $"mutation{{deleteSeason(seasonId: {seasonId})}}";

            var deleteTask = GraphQLRequest(mutation, "deleteSeason");
            deleteTask.Wait();

            await AssertSeasonCountAsync(_TestDataCnt - 1);
            Assert.Null(await GetSeasonAsync(seasonId));
        }


        private string SeasonInput(Season season)
        {
            return $"{{name: \"{season.Name}\"}}";
        }

        private async Task<Season> GetSeasonAsync(int seasonId)
        {
            string query = $"season(id: {seasonId}){{{fragment}}}";
            return await SingleQueryRequest(query, "season");
        }

        private async Task AssertSeasonCountAsync(int expectedCnt)
        {
            List<Season> seasons = await ListQueryRequest($"seasons{{{fragment}}}", "seasons");
            Assert.Equal(expectedCnt, seasons.Count);
        }
    }
}
