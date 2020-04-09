﻿using RamblerAcademyAPI.GraphQL.Client;
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
    
    public class CourseConsumer
    {
        private readonly GraphQLClient _client;

        public CourseConsumer(GraphQLClient client)
        {
            _client = client;
        }

        private const string courseFragment = @"
            id
            name
            courseNumber
            subject{
                id
                name
            }
            courseSections{
                crn
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
            string query = string.Format(@"
                {{
                    courses{{
                        {0}
                    }}
                }}
            ", courseFragment);

            string resultString = await _client.Query(query);
            var data = DataParser.ParseDataFromString(resultString, "courses");
            return JsonConvert.DeserializeObject<List<Course>>(data);
        }

        public async Task<Course> GetCourseByIdAsync(int courseId)
        {
            string query = string.Format(@"
                {{
                    course(id: {0}){{
                        {1}
                    }}
                }}
            ", courseId, courseFragment);
            
            string resultString = await _client.Query(query);
            Console.WriteLine(resultString);
            var data = DataParser.ParseDataFromString(resultString, "course");
            return JsonConvert.DeserializeObject<Course>(data);
        }

        public async Task<Course> CreateCourseAsync(Course course)
        {
            string mutation = string.Format(@"
                mutation{{
                    createCourse(course: {0}){{
                        {1}
                    }}
                }}
            ", courseInput(course), courseFragment);
            Console.WriteLine(mutation);
            string resultString = await _client.Query(mutation);
            var data = DataParser.ParseDataFromString(resultString, "createCourse");
            return JsonConvert.DeserializeObject<Course>(data);
        }

        public async Task<Course> UpdateCourseAsync(int id, Course course)
        {
            string mutation = string.Format(@"
                mutation{{
                    updateCourse(courseId: {0}, course: {1}){{
                        {2}
                    }}
                }}
            ", id, courseInput(course), courseFragment);

            string resultString = await _client.Query(mutation);
            var data = DataParser.ParseDataFromString(resultString, "updateCourse");
            return JsonConvert.DeserializeObject<Course>(data);
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            string mutation = string.Format(@"
                mutation{{
                    deleteCourse(courseId: {0})
                }}
            ", id);
            await _client.Query(mutation);
            return true;
        }

        private string courseInput(Course course)
        {
            var fields = new CourseInputType().Fields;
            JObject jObject = JObject.FromObject(course);
            return GraphQLInputString.Create(fields, jObject);
        }
    }
}