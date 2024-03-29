﻿using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;


using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

using RamblerAcademyAPI.Util;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using System.Net.Http;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
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
                subject { abbreviation }
            }
        ";
        public SubjectConsumer(IHttpClientFactory factory)
        {
            _client = new GraphQLClient(factory.CreateClient(name: "graphQLClient"));
        }

        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            string query = string.Format("subjects{{ {0} }}", subjectFragment);

            string data = await _client.Query(query, "subjects");
            return JsonConvert.DeserializeObject<List<Subject>>(data);
        }

        public async Task<Subject> GetSubjectByIdAsync(int id)
        {
            string query = string.Format(@"
                   subject(id: {0}){{  
                        {1}
                    }}
            ", id, subjectFragment);

            string data = await _client.Query(query, "subject");
            return JsonConvert.DeserializeObject<Subject>(data);
        }

        public async Task<Subject> CreateSubjectAsync(Subject subject)
        {
            string mutation = string.Format(@"
                    createSubject(subject: {0}){{
                        {1}
                    }}
            ", subjectInput(subject), subjectFragment);

            string data = await _client.Mutation(mutation, "createSubject");
            return JsonConvert.DeserializeObject<Subject>(data);
        }

        public async Task<Subject> UpdateSubjectAsync(int subjectId, Subject subject)
        {
            string mutation = string.Format(@"
                    updateSubject(subjectId: {0}, subject: {1}){{
                        {2}
                    }}
            ", subjectId, subjectInput(subject), subjectFragment);

            string data = await _client.Mutation(mutation, "updateSubject");
            return JsonConvert.DeserializeObject<Subject>(data);
        }

        public async Task<bool> DeleteSubjectAsync(int subjectId)
        {
           await _client.Mutation($"deleteSubject(subjectId: {subjectId})", "deleteSubject");
            return true;
        }

        private string subjectInput(Subject subject)
        {
            var fields = new SubjectInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, subject);
        }
    }
}
