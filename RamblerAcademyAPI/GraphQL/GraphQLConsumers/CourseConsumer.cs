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
    public class CourseConsumer
    {
        private readonly GraphQLClient _client;

        public CourseConsumer(IHttpClientFactory factory)
        {
            _client = new GraphQLClient(factory.CreateClient(name: "graphQLClient"));
        }

        private const string courseFragment = @"
            id
            name
            courseNumber
            subject{
                id
                name
            }
            subjectId
            courseSections{
                courseReferenceNumber
                semester{
                    id
                    year
                    season{
                        id
                        name
                    }
                }
            }
        ";

        public async Task<List<Course>> GetAllCoursesAsync()
        {
            string query = string.Format("courses{{ {0} }}", courseFragment);
         
            string data = await _client.Query(query, "courses");
            return JsonConvert.DeserializeObject<List<Course>>(data);
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            string query = string.Format(@"
                    course(id: {0}){{
                        {1}
                    }}
            ", courseId, courseFragment);
            
            string data = await _client.Query(query, "course");
            return JsonConvert.DeserializeObject<Course>(data);
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            string mutation = string.Format(@"
                    createCourse(course: {0}){{
                        {1}
                    }}
            ", courseInput(course), courseFragment);

            string data = await _client.Mutation(mutation, "createCourse");
            return JsonConvert.DeserializeObject<Course>(data);
        }

        public async Task<Course> UpdateCourseAsync(int id, Course course)
        {
            string mutation = string.Format(@"
                    updateCourse(courseId: {0}, course: {1}){{
                        {2}
                    }}
            ", id, courseInput(course), courseFragment);

            string data = await _client.Mutation(mutation, "updateCourse");
            return JsonConvert.DeserializeObject<Course>(data);
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            await _client.Mutation($"deleteCourse(courseId: {id})", "deleteCourse");
            return true;
        }

        private string courseInput(Course course)
        {
            var fields = new CourseInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, course);
        }
    }
}
