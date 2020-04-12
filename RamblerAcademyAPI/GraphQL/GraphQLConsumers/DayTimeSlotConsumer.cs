using RamblerAcademyAPI.GraphQL.Client;
using RamblerAcademyAPI.Models;

using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RamblerAcademyAPI.Util;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;


namespace RamblerAcademyAPI.GraphQL.GraphQLConsumers
{
    public class DayTimeSlotConsumer
    {
        private readonly GraphQLClient _client;
        private readonly string dayTimeSlotFragment = @"
            day { id name } timeSlot{ id startTime endTime }
        ";
        public DayTimeSlotConsumer(GraphQLClient client)
        {
            _client = client;
        }

        // GET dayTimeSlots/dayId/{dayId}
        public async Task<IEnumerable<DayTimeSlot>> GetAllDayTimeSlotsByDay(int dayId)
        {
            string query = $"dayTimeSlotsPerDay(dayId: {dayId}){{ {dayTimeSlotFragment} }}";

            string data = await _client.Query(query, "dayTimeSlotsPerDay");
            return JsonConvert.DeserializeObject<IEnumerable<DayTimeSlot>>(data);
        } 

        public async Task<IEnumerable<DayTimeSlot>> GetAllDayTimeSlotsPerTimeSlot(int timeSlotId)
        {
            string query = @$"dayTimeSlotsPerTimeSlot(timeSlotId: {timeSlotId})
                                {{ {dayTimeSlotFragment} }}";

            string data = await _client.Query(query, "dayTimeSlotsPerTimeSlot");
            return JsonConvert.DeserializeObject<IEnumerable<DayTimeSlot>>(data);
        }

        public async Task<DayTimeSlot> CreateDayTimeSlot(DayTimeSlot dayTimeSlot)
        {
            string mutation = $@"createDayTimeSlot(dayTimeSlot: {dayTimeSlotInput(dayTimeSlot)}){{ 
                                      {dayTimeSlotFragment} }}";

            string data = await _client.Mutation(mutation, "createDayTimeSlot");
            return JsonConvert.DeserializeObject<DayTimeSlot>(data);
        }

        public async Task<bool> DeleteDayTimeSlot(int dayId, int timeSlotId)
        {
            string mutation = $"deleteDayTimeSlot(dayId: {dayId}, timeSlotId: {timeSlotId})";

            await _client.Mutation(mutation, "deleteDayTimeSlot");
            return true;
        }

        private string dayTimeSlotInput(DayTimeSlot dayTimeSlot)
        {
            var fields = new DayTimeSlotInputType().Fields;
            return GraphQLQueryUtil.InputObject(fields, dayTimeSlot);
        }
    }
}
