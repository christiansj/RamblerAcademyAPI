using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;

using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RamblerAcademyAPI.Util;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using System;
using Newtonsoft.Json.Converters;

namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class TimeSlotConsumer
    {
        private readonly GraphQLClient _client;
        private readonly string timeSlotFragment = @"
            id startTime endTime  
        ";
        private readonly JsonSerializerSettings jsonSerializerSettings;
        public TimeSlotConsumer(GraphQLClient client)
        {
            _client = client;
            jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new IsoDateTimeConverter());
        }

        public async Task<IEnumerable<TimeSlot>> GetAllTimeSlotsAsync()
        {
            string query = string.Format("timeSlots{{ {0} }}", timeSlotFragment);
            JsonConverter converter = new IsoDateTimeConverter();
         
            string data = await _client.Query(query, "timeSlots");
            return JsonConvert.DeserializeObject<IEnumerable<TimeSlot>>(data, converter);
        }

        public async Task<TimeSlot> GetTimeSlotByIdAsync(int id)
        {
            string query = $"timeSlot(id: {id}){{ {timeSlotFragment}}}";

            string data = await _client.Query(query, "timeSlot");
            return JsonConvert.DeserializeObject<TimeSlot>(data);
        }

        public async Task<TimeSlot> CreateTimeSlotAsync(TimeSlot timeSlot)
        {
            string mutation = $@"
                 createTimeSlot(timeSlot: {timeSlotInput(timeSlot)}){{
                        {timeSlotFragment}
                 }}";
            string data = await _client.Mutation(mutation, "createTimeSlot");
            return JsonConvert.DeserializeObject<TimeSlot>(data);
        }

        public async Task<TimeSlot> UpdateTimeSlotAsync(int timeSlotId, TimeSlot timeSlot)
        {
            string mutation = $@"
                updateTimeSlot(timeSlotId: {timeSlotId}, timeSlot: {timeSlotInput(timeSlot)}){{
                    {timeSlotFragment}
                }}
            ";

            string data = await _client.Mutation(mutation, "updateTimeSlot");
            return JsonConvert.DeserializeObject<TimeSlot>(data);
        }

        public async Task<bool> DeleteTimeSlotAsync(int timeSlotId)
        {
            string mutation = $"deleteTimeSlot(timeSlotId: {timeSlotId})";

            await _client.Mutation(mutation, "deleteTimeSlot");
            return true;
        }

        private string timeSlotInput(TimeSlot timeSlot)
        {
            var fields = new TimeSlotInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, timeSlot);
        }
    }
}
