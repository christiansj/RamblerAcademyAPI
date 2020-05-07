using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;

using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RamblerAcademyAPI.Util;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using System.Net.Http;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class EnrollmentConsumer
    {
        private readonly GraphQLClient _client;
        private string fragment = @"courseReferenceNumber studentId
                            student { firstName lastName }
                            courseSection{ course{ name } }";

        public EnrollmentConsumer(IHttpClientFactory factory)
        {
            _client = new GraphQLClient(factory.CreateClient(name: "graphQLClient"));
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
            
            string mutation = $"createEnrollment(enrollment: {enrollmentInput(enrollment)}){{{fragment}}}";
            string data = await _client.Mutation(mutation, "createEnrollment");

            return JsonConvert.DeserializeObject<Enrollment>(data);
        }

        public async Task<bool> DeleteEnrollmentAsync(long studentId, int crn)
        {
            string mutation = $"deleteEnrollment(studentId: {studentId}, crn: {crn})";
            await _client.Mutation(mutation, "deleteEnrollment");

            return true;
        }

        private string enrollmentInput(Enrollment enrollment)
        {
            var fields = new EnrollmentInputType().Fields;

            return GraphQLQueryUtil.InputObject(fields, enrollment);
        }
    }
}
