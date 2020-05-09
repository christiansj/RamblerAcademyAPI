using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers;

using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;

using RamblerAcademyAPI.Util;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using System.Net.Http;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class CourseSectionConsumer
    {
        private GraphQLClient _client;
        private string courseSectionFragment = @"
            courseReferenceNumber, sectionNumber, courseId, semesterId, classroomId
            course{ id name }
            semester{
                year
                season{ id name }
            }
            enrollments { 
                student { abcId firstName lastName }  
            }
            courseSectionDayTimeSlots{
                dayTimeSlot {
                    day { id name abbreviation }
                    timeSlot { id startTime endTime }
                }
            }
        ";
        public CourseSectionConsumer(IHttpClientFactory factory)
        {
            _client = new GraphQLClient(factory.CreateClient(name: "graphQLClient"));
        }

        public async Task<IEnumerable<CourseSection>> GetAllCourseSectionsAsync()
        {
            string query = string.Format("courseSections{{ {0} }}", 
                                courseSectionFragment);
          
            string data = await _client.Query(query, "courseSections");
            return JsonConvert.DeserializeObject<IEnumerable<CourseSection>>(data);
        }

        public async Task<CourseSection> GetCourseSectionByIdAsync(int crn)
        {
            string query = string.Format(@"
                    courseSection(crn: {0}){{
                        {1}
                    }}
            ", crn, courseSectionFragment);

            string data = await _client.Query(query, "courseSection");
            return JsonConvert.DeserializeObject<CourseSection>(data);
        }

        public async Task<IEnumerable<CourseSection>> GetAllPerSemesterAndSubject(int semesterId, int subjectId)
        {
            string queryName = "courseSectionsPerSemesterAndSubject";
            string query = $"{queryName}(semesterId: {semesterId}, subjectId: {subjectId}){{{courseSectionFragment}}}";

            string data = await _client.Query(query, queryName);
            return JsonConvert.DeserializeObject<IEnumerable<CourseSection>>(data);
        }

        public async Task<CourseSection> CreateCourseSectionAsync(CourseSection courseSection)
        {
            string mutation = string.Format(@"
                    createCourseSection(courseSection: {0}){{
                        {1}
                    }}
            ", courseSectionInput(courseSection), courseSectionFragment);

            string data = await _client.Mutation(mutation, "createCourseSection");
            return JsonConvert.DeserializeObject<CourseSection>(data);
        }

        public async Task<CourseSection> UpdateCourseSectionAsync(int crn, CourseSection courseSection)
        {
            string mutation = string.Format(@"
                updateCourseSection(crn: {0}, courseSection: {1}){{
                    {2}
                }}
            ", crn, courseSectionInput(courseSection), courseSectionFragment);

            string data = await _client.Mutation(mutation, "updateCourseSection");
            return JsonConvert.DeserializeObject<CourseSection>(data);
        }

        public async Task<bool> DeleteCourseSectionAsync(int crn)
        {
            await _client.Mutation($"deleteCourseSection(crn: {crn})", "deleteCourseSection");
            return true;
        }

        private string courseSectionInput(CourseSection courseSection)
        {
            var fields = new CourseSectionInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, courseSection);
        }
    }
}
