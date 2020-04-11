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
    public class ClassroomConsumer
    {
        private readonly GraphQLClient _client;
        private readonly string classroomFragment = @"
            id
            floor
            hallwayNumber
            roomNumber
            building{
                name
            }
        ";
        public ClassroomConsumer(GraphQLClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Classroom>> GetAllClassroomAsync()
        {
            string query = string.Format("classrooms{{ {0} }}",
                                classroomFragment);

            string data = await _client.Query(query, "classrooms");
            return JsonConvert.DeserializeObject<IEnumerable<Classroom>>(data);
        }

        public async Task<Classroom> GetClassroomByIdAsync(int classroomId)
        {
            string query = string.Format("classroom(id: {0}){{ {1} }}",
                        classroomId, classroomFragment);

            string data = await _client.Query(query, "classroom");
            return JsonConvert.DeserializeObject<Classroom>(data);
        }

        public async Task<Classroom> CreateClassroomAsync(Classroom classroom)
        {
            string mutation = string.Format(@"
                        createClassroom(classroom: {0}){{ 
                                   {1} 
                        }}", classroomInput(classroom), classroomFragment);

            string data = await _client.Mutation(mutation, "createClassroom");
            return JsonConvert.DeserializeObject<Classroom>(data);
        }

        public async Task<Classroom> UpdateClassroomAsync(int classroomId, Classroom classroom)
        {
            string mutation = string.Format(@"
                      updateClassroom(classroomId: {0}, classroom: {1}){{
                            {2}
                      }}", classroomId, classroomInput(classroom), classroomFragment);

            string data = await _client.Mutation(mutation, "updateClassroom");
            return JsonConvert.DeserializeObject<Classroom>(data);
        }

        public async Task<bool> DeleteClassroomAsync(int classroomId)
        {
            string mutation = $"deleteClassroom(classroomId: {classroomId})";
            await _client.Mutation(mutation, "deleteClassroom");

            return true;
        }

        private string classroomInput(Classroom classroom)
        {
            var fields = new ClassroomInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, classroom);
        }
    }
}
