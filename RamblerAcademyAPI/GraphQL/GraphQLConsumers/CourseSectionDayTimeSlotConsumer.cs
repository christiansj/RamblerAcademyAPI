﻿using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;

using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RamblerAcademyAPI.Util;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class CourseSectionDayTimeSlotConsumer
    {
        private readonly GraphQLClient _client;
        private readonly string fragment = @"
                courseReferenceNumber day { id name } courseSection{ course { name } }
            ";
        public CourseSectionDayTimeSlotConsumer(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<CourseSectionDayTimeSlot>> GetAllPerCourseSectionAsync(int crn)
        {
            const string  queryName = "courseSectionDayTimeSlotsPerCourseSection";
            string query = $"{queryName}(crn: {crn}){{{fragment}}}";
            string data = await _client.Query(query, queryName);
            return JsonConvert.DeserializeObject<IEnumerable<CourseSectionDayTimeSlot>>(data);
        }

        public async Task<IEnumerable<CourseSectionDayTimeSlot>> GetAllPerDayAsync(int dayId)
        {
            const string queryName = "courseSectionDayTimeSlotsPerDay";
            string query = $"{queryName}(dayId: {dayId}){{{fragment}}}";
            string data = await _client.Query(query, queryName);
            return JsonConvert.DeserializeObject<IEnumerable<CourseSectionDayTimeSlot>>(data);
        }

        public async Task<CourseSectionDayTimeSlot> CreateAsync(CourseSectionDayTimeSlot csdt)
        {
            const string mutationName = "createCourseSectionDayTimeSlot";
            string mutation = string.Format(@"{0}(courseSectionDayTimeSlot: {1}){{
                  {2} }}", mutationName, input(csdt), fragment);

            string data = await _client.Mutation(mutation, mutationName);
            return JsonConvert.DeserializeObject<CourseSectionDayTimeSlot>(data);
        }

        public async Task<bool> DeleteAsync(int crn, int dayId, int timeSlotId)
        {
            const string mutationName = "deleteCourseSectionDayTimeSlot";
            string mutation = string.Format("{0}(crn: {1}, dayId: {2}, timeSlotId: {3})",
                        mutationName, crn, dayId, timeSlotId);

            await _client.Mutation(mutation, mutationName);
            return true;
        }

        private string input(CourseSectionDayTimeSlot csdt)
        {
            var fields = new CourseSectionDayTimeSlotInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, csdt);
        }
    }
}
