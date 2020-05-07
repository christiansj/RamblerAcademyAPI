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
    [Collection("Classroom GraphQL Tests")]
    public class ClassroomGraphQLTests : GraphQLIntegrationTest<Classroom>
    {
        private readonly int _TestDataCnt;
        private readonly string fragment = "id floor hallwayNumber roomNumber buildingId";
        public ClassroomGraphQLTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Classrooms().Count;
        }

        // classrooms
        [Fact]
        public async void ClassroomsQueryTest()
        {
            List<Classroom> classrooms = await ListQueryRequest($"classrooms{{{fragment}}}", "classrooms");

            AssertObjectsAreEqual(TestData.Classrooms(), classrooms);
        }

        // classroom(id)
        [Fact]
        public async void ClassroomQueryTest()
        {
            const int classroomId = 4;
            Classroom expectedClassroom = TestData.Classrooms().Find(c => c.Id == classroomId);

            Classroom classroom = await GetClassroomAsync(classroomId);

            AssertObjectsAreEqual(expectedClassroom, classroom);
        }

        // createClassroom(classroom)
        [Fact]
        public async void ClassroomCreateMutation()
        {
            Classroom expectedClassroom = new Classroom(_TestDataCnt + 1, 2, 11, 1, 40, 1);
            string mutation = $"createClassroom(classroom: {ClassroomInput(expectedClassroom)}){{{fragment}}}";

            var createTask = MutationRequest(mutation, "createClassroom");
            createTask.Wait();

            await AssertRecordCount(_TestDataCnt + 1, "classrooms", fragment);
            AssertObjectsAreEqual(expectedClassroom, createTask.Result);
            AssertObjectsAreEqual(expectedClassroom, await GetClassroomAsync(expectedClassroom.Id));
        }

        // updateClassroom(classroomId, classroom)
        [Fact]
        public async void ClassroomUpdateMutationTest()
        {
            const int classroomId = 4;
            Classroom expectedClassroom = new Classroom(classroomId, 2, 2, 22, 70, 2);
            string mutation = $@"updateClassroom(classroomId: {classroomId}, classroom: {ClassroomInput(expectedClassroom)})
                            {{{fragment}}}";

            Classroom newClassroom = await MutationRequest(mutation, "updateClassroom");

            AssertObjectsAreEqual(expectedClassroom, newClassroom);
            AssertObjectsAreEqual(expectedClassroom, await GetClassroomAsync(classroomId));
        }

        [Fact]
        public async void ClassroomDeleteMutationTest()
        {
            const int classroomId = 5;
            string mutation = $"mutation{{deleteClassroom(classroomId: {classroomId})}}";

            var deleteTask = GraphQLRequest(mutation, "deleteClassroom");
            deleteTask.Wait();

            await AssertRecordCount(_TestDataCnt - 1, "classrooms", fragment);
            Assert.Null(await GetClassroomAsync(classroomId));
        }

        private async Task<Classroom> GetClassroomAsync(int classroomId)
        {
            string query = $"classroom(id: {classroomId}){{{fragment}}}";
            return await SingleQueryRequest(query, "classroom");
        }

        private string ClassroomInput(Classroom classroom)
        {
            var fields = new ClassroomInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, classroom);
        }
    }
}
