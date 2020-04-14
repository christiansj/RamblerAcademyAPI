using Newtonsoft.Json;
using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using RamblerAcademyAPI.GraphQL.GraphQLConsumers.Util;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using Newtonsoft.Json.Linq;
using RamblerAcademyAPI.Util;
using System.Net.Http;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class SemesterConsumer
    {
        private readonly GraphQLClient _client;
        private string semesterFragment = @"
            id
            year
            startDate
            endDate
            season{
                id
                name
            }
        ";
    
        public SemesterConsumer(IHttpClientFactory factory)
        {
            _client = new GraphQLClient(factory.CreateClient(name: "graphQLClient"));
        }

        public async Task<IEnumerable<Semester>> GetAllSemestersAsync()
        {
            string query = string.Format("semesters{{ {0} }}", semesterFragment);

            string data = await _client.Query(query, "semesters");
            return JsonConvert.DeserializeObject<List<Semester>>(data);
        }

        public async Task<Semester> GetSemesterByIdAsync(int semesterId)
        {
            string query = string.Format(@"
                    semester(id: {0}){{
                        {1}
                    }}
                ", semesterId, semesterFragment);

            string data = await _client.Query(query, "semester");
            return JsonConvert.DeserializeObject<Semester>(data);
        }

        public async Task<Semester> CreateSemesterAsync(Semester semester)
        {
            string mutation = string.Format(@"
                createSemester(semester: {0}){{
                   {1}
                }}
            ", semesterInput(semester), semesterFragment);

            string data = await _client.Mutation(mutation, "createSemester");
            return JsonConvert.DeserializeObject<Semester>(data);
        }

        public async Task<Semester> UpdateSemesterAsync(int semesterId, Semester semester)
        {
            string mutation = string.Format(@"
                updateSemester(semesterId: {0}, semester: {1}){{
                     {2}
                }}
            ", semesterId, semesterInput(semester), semesterFragment);

            string data = await _client.Mutation(mutation, "updateSemester");
            return JsonConvert.DeserializeObject<Semester>(data);
        }

        public async Task<bool> DeleteSemesterAsync(int semesterId)
        {
            await _client.Mutation($"deleteSemester(semesterId: {semesterId})", "deleteSemester");
            return true;
        }

        private string semesterInput(Semester semester)
        {
            var fields = new SemesterInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, semester);
        }
    }
}
