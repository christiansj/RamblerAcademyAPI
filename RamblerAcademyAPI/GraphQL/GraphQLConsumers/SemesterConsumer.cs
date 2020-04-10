using Newtonsoft.Json;
using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

using RamblerAcademyAPI.GraphQL.GraphQLConsumers.Util;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using Newtonsoft.Json.Linq;
using RamblerAcademyAPI.Util;

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
    
        public SemesterConsumer(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Semester>> GetAllSemestersAsync()
        {
            string query = string.Format(@"
                {{
                    semesters{{ 
                        {0}
                    }}
                }}
            ", semesterFragment);

            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "semesters");
            return JsonConvert.DeserializeObject<List<Semester>>(data);
        }

        public async Task<Semester> GetSemesterByIdAsync(int semesterId)
        {
            string query = string.Format(@"
                {{
                    semester(id: {0}){{
                        {1}
                    }}
                }}", semesterId, semesterFragment);

            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "semester");
            return JsonConvert.DeserializeObject<Semester>(data);
        }

        public async Task<Semester> CreateSemesterAsync(Semester semester)
        {
            string mutation = string.Format(@"
                mutation{{
                    createSemester(semester: {0}){{
                        {1}
                    }}
                }}
            ", semesterInput(semester), semesterFragment);

            string resultString = await _client.Query(mutation);
            var data = DataParser.ParseDataFromString(resultString, "createSemester");
            return JsonConvert.DeserializeObject<Semester>(data);
        }

        public async Task<Semester> UpdateSemesterAsync(int semesterId, Semester semester)
        {
            string mutation = string.Format(@"
                mutation{{
                    updateSemester(semesterId: {0}, semester: {1}){{
                        {2}
                    }}
                }}
            ", semesterId, semesterInput(semester), semesterFragment);

            string resultString = await _client.Query(mutation);
            var data = DataParser.ParseDataFromString(resultString, "updateSemester");
            return JsonConvert.DeserializeObject<Semester>(data);
        }

        public async Task<bool> DeleteSemesterAsync(int semesterId)
        {
            string mutation = string.Format(@"
                mutation{{
                    deleteSemester(semesterId: {0})
                }}
            ", semesterId);
            await _client.Query(mutation);
            return true;
        }

        private string semesterInput(Semester semester)
        {
            var fields = new SemesterInputType().Fields;
            JObject jObject = JObject.FromObject(semester);
            return GraphQLInputString.Create(fields, jObject);

        }
    }
}
