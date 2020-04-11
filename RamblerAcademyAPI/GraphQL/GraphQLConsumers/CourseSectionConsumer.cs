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


namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class CourseSectionConsumer
    {
        private GraphQLClient _client;
        private string courseSectionFragment = @"
            courseReferenceNumber
            sectionNumber
            course{
                id
                name
            }
            semester{
                year
                season{
                    id
                    name
                }
            }
        ";
        public CourseSectionConsumer(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CourseSection>> GetAllCourseSectionsAsync()
        {
            string query = string.Format(@"
                {{
                    courseSections{{
                        {0}
                    }}
                }}
            ", courseSectionFragment);

            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "courseSections");
            return JsonConvert.DeserializeObject<IEnumerable<CourseSection>>(data);
        }

        public async Task<CourseSection> GetCourseSectionByIdAsync(int crn)
        {
            string query = string.Format(@"
                {{
                    courseSection(crn: {0}){{
                        {1}
                    }}
                }}
            ", crn, courseSectionFragment);

            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "courseSection");
            return JsonConvert.DeserializeObject<CourseSection>(data);
        }

        public async Task<CourseSection> CreateCourseSectionAsync(CourseSection courseSection)
        {
            string mutation = string.Format(@"
                    createCourseSection(courseSection: {0}){{
                        {1}
                    }}
            ", courseSectionInput(courseSection), courseSectionFragment);

            string resultString = await _client.Mutation(mutation);
            var data = DataParser.ParseDataFromString(resultString, "createCourseSection");
            return JsonConvert.DeserializeObject<CourseSection>(data);
        }

        public async Task<CourseSection> UpdateCourseSectionAsync(int crn, CourseSection courseSection)
        {
            string mutation = string.Format(@"
                updateCourseSection(crn: {0}, courseSection: {1}){{
                    {2}
                }}
            ", crn, courseSectionInput(courseSection), courseSectionFragment);

            string resultString = await _client.Mutation(mutation);
            var data = DataParser.ParseDataFromString(resultString, "updateCourseSection");
            return JsonConvert.DeserializeObject<CourseSection>(data);
        }

        public async Task<bool> DeleteCourseSectionAsync(int crn)
        {
            await _client.Mutation($"deleteCourseSection(crn: {crn})");
            return true;
        }

        private string courseSectionInput(CourseSection courseSection)
        {
            var fields = new CourseSectionInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, courseSection);
        }
    }
}
