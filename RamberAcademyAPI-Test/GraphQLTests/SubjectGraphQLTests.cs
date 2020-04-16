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
    [Collection("Subject GraphQL Tests")]
    public class SubjectGraphQLTests : GraphQLIntegrationTest<Subject>
    {
        private readonly int _TestDataCnt;
        private const string fragment = "id name abbreviation";

        public SubjectGraphQLTests(ITestOutputHelper output) : base(output)
        {
            _TestDataCnt = TestData.Subjects().Count;
        }
        
        [Fact]
        public async void SubjectsQueryTest()
        {
            string query = $"subjects{{{fragment}}}";
            List<Subject> subjects = await ListQueryRequest(query, "subjects");

            AssertObjectsAreEqual(subjects, TestData.Subjects());
        }

        [Fact]
        public async void SubjectQueryTest()
        {
            const int subjectId = 2;
            string query = $"subject(id: {subjectId}){{{fragment}}}";
            Subject expectedSubject = TestData.Subjects().Find(s => s.Id == subjectId);

            Subject subject = await SingleQueryRequest(query, "subject");

            AssertObjectsAreEqual(expectedSubject, subject);
        }

        [Fact]
        public async void SubjectCreateMutationTest()
        {
            Subject expectedSubject = new Subject(_TestDataCnt + 1, "New Subject", "NEW");
            string mutation = @$"createSubject(subject: {subjectInput(expectedSubject)})
                                {{{fragment}}}";
                                

            var createTask =  MutationRequest(mutation, "createSubject");
            createTask.Wait();
            
            AssertObjectsAreEqual(expectedSubject, createTask.Result);

            await AssertRecordCount(_TestDataCnt + 1, "subjects", fragment);               
        }

        [Fact]
        public async void SubjectUpdateMutationTest()
        {
            Subject expectedSubject = new Subject(2, "New English Course", "ENG");
            string mutation = string.Format("updateSubject(subjectId: {0}, subject: {1})" +
                "           {{{2}}}", expectedSubject.Id, subjectInput(expectedSubject), fragment);

            Subject newSubject = await MutationRequest(mutation, "updateSubject");

            AssertObjectsAreEqual(expectedSubject, newSubject);
        }

        [Fact]
        public async void SubjectDeleteMutationTest()
        {
            const int subjectId = 3;
            string mutation = $"mutation{{deleteSubject(subjectId: {subjectId})}}";

            var deleteTask = GraphQLRequest(mutation, "deleteSubject");
            deleteTask.Wait();

            await AssertRecordCount(_TestDataCnt - 1, "subjects", fragment);
        }

        private string subjectInput(Subject subject)
        {
            var fields = new SubjectInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, subject);
        }
    }
}
