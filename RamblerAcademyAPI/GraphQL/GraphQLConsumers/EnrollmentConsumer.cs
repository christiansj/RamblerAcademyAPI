using Newtonsoft.Json;
using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.Models;
using RamblerAcademyAPI.Util;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class EnrollmentConsumer
    {
        private readonly GraphQLClient _client;
        private readonly string fragment = @"courseReferenceNumber studentId
                            student { firstName lastName }
                            courseSection{ course{ name } }";

        public EnrollmentConsumer(IHttpClientFactory factory)
        {
            _client = new GraphQLClient(factory.CreateClient(name: "graphQLClient"));
        }

        public async Task<Enrollment> GetEnrollmentAsync(long studentId, int crn)
        {
            string query = $"enrollment(studentId: {studentId}, crn: {crn}){{{fragment}}}";
            string data = await _client.Query(query, "enrollment");

            return JsonConvert.DeserializeObject<Enrollment>(data);
        }
        public async Task<IEnumerable<Enrollment>> GetEnrollmentsPerStudentAsync(long studentId)
        {
            string query = $"enrollmentsPerStudent(studentId: {studentId}){{{ fragment }}}";
            string data = await _client.Query(query, "enrollmentsPerStudent");

            return JsonConvert.DeserializeObject<IEnumerable<Enrollment>>(data);
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsPerCourseSection(int crn)
        {
            string query = $"enrollmentsPerCourseSection(crn: {crn}){{{fragment}}}";
            string data = await _client.Query(query, "enrollmentsPerCourseSection");

            return JsonConvert.DeserializeObject<IEnumerable<Enrollment>>(data);
        }

        public async Task<Enrollment> CreateEnrollmentAsync(Enrollment enrollment)
        {
            
            string mutation = $"createEnrollment(enrollment: {EnrollmentInput(enrollment)}){{{fragment}}}";
            string data = await _client.Mutation(mutation, "createEnrollment");

            return JsonConvert.DeserializeObject<Enrollment>(data);
        }

        public async Task<bool> DeleteEnrollmentAsync(long studentId, int crn)
        {
            string mutation = $"deleteEnrollment(studentId: {studentId}, crn: {crn})";
            await _client.Mutation(mutation, "deleteEnrollment");

            return true;
        }

        private string EnrollmentInput(Enrollment enrollment)
        {
            var fields = new EnrollmentInputType().Fields;

            return GraphQLQueryUtil.InputObject(fields, enrollment);
        }
    }
}
