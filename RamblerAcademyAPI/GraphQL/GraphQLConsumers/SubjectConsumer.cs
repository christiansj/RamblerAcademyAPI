using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers.Util;

using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using RamblerAcademyAPI.Util;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using Newtonsoft.Json.Linq;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers.Util
{
    public class SubjectConsumer
    {
        private readonly GraphQLClient _client;
        private string subjectFragment = @"
            id
            name
            abbreviation
            courses{
                id
                courseNumber
                name
            }
        ";
        public SubjectConsumer(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            string query = string.Format("subjects{{ {0} }}", subjectFragment);

            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "subjects");
            return JsonConvert.DeserializeObject<List<Subject>>(data);
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            string query = string.Format(@"
                   subject(id: {0}){{  
                        {1}
                    }}
            ", id, subjectFragment);

            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "subject");
            return JsonConvert.DeserializeObject<Subject>(data);
        }

        public async Task<Subject> CreateSubjectAsync(Subject subject)
        {
            string mutation = string.Format(@"
                    createSubject(subject: {0}){{
                        {1}
                    }}
            ", subjectInput(subject), subjectFragment);

            string resultString = await _client.Mutation(mutation);
            var data = DataParser.ParseDataFromString(resultString, "createSubject");
            return JsonConvert.DeserializeObject<Subject>(data);
        }

        public async Task<Subject> UpdateSubjectAsync(int subjectId, Subject subject)
        {
            string mutation = string.Format(@"
                    updateSubject(subjectId: {0}, subject: {1}){{
                        {2}
                    }}
            ", subjectId, subjectInput(subject), subjectFragment);

            string resultString = await _client.Mutation(mutation);
            var data = DataParser.ParseDataFromString(resultString, "updateSubject");
            return JsonConvert.DeserializeObject<Subject>(data);
        }

        public async Task<bool> DeleteSubjectAsync(int subjectId)
        {
           await _client.Mutation($"deleteSubject(subjectId: {subjectId})");
            return true;
        }

        private string subjectInput(Subject subject)
        {
            var fields = new SubjectInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, subject);
        }
    }
}
