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
    public class DayGraphQLTests : GraphQLIntegrationTest<Day>
    {
        
        private readonly string fragment = "id name abbreviation";

        public DayGraphQLTests(ITestOutputHelper output) : base(output)
        {
            
        }

        // days
        [Fact]
        public async void DaysQueryTest()
        {
            List<Day> days = await ListQueryRequest($"days{{{fragment}}}", "days");

            AssertObjectsAreEqual(TestData.Days(), days);
        }

        // day(id)
        [Fact]
        public async void DayQueryTest()
        {
            const int dayId = 2;
            Day expectedDay = TestData.Days().Find(d => d.Id == dayId);
            string query = $"day(id: {dayId}){{{fragment}}}";

            Day day = await SingleQueryRequest(query, "day");

            AssertObjectsAreEqual(expectedDay, day);
        } 
    }
}
