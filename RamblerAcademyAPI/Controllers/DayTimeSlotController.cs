using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers;
using RamblerAcademyAPI.GraphQL.GraphQLUserErrors;
using RamblerAcademyAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RamblerAcademyAPI.Controllers
{
    [Route("api/[controller]")]
    public class DayTimeSlotController : Controller
    {
        private readonly DayTimeSlotConsumer _consumer;

        public DayTimeSlotController(DayTimeSlotConsumer consumer)
        {
            _consumer = consumer;
        }
        // GET: api/<controller>/day/5
        [HttpGet("day/{dayId}")]
        public async Task<ActionResult> GetPerDay(int dayId)
        {

            IEnumerable<DayTimeSlot> dayTimeSlots =
                await _consumer.GetAllDayTimeSlotsByDay(dayId);

            return Ok(dayTimeSlots);
        }

        // GET api/<controller>/timeSlot/5
        [HttpGet("timeSlot/{timeSlotId}")]
        public async Task<ActionResult> GetPerTimeSlot(int timeSlotId)
        {
            IEnumerable<DayTimeSlot> dayTimeSlots =
                await _consumer.GetAllDayTimeSlotsPerTimeSlot(timeSlotId);

            return Ok(dayTimeSlots);
        }

        // GET /api/<controller>/day/1/timeSlot/2
        [HttpGet("day/{dayId}/timeSlot/{timeSlotId}")]
        public async Task<ActionResult> GetByIds(int dayId, int timeSlotId)
        {
            DayTimeSlot dayTimeSlot = await _consumer.GetDayTimeSlotByIds(dayId, timeSlotId);

            if(dayTimeSlot == null)
            {
                return NotFound();
            }

            return Ok(dayTimeSlot);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult> Post(DayTimeSlot dayTimeSlot)
        {
            DayTimeSlot newDayTimeSlot = await _consumer.CreateDayTimeSlot(dayTimeSlot);
            return Ok(newDayTimeSlot);
        }

        // DELETE api/<controller>/day/5/timeSlot/6
        [HttpDelete("day/{dayId}/timeSlot/{timeSlotId}")]
        public async Task<ActionResult> Delete(int dayId, int timeSlotId)
        {
            try
            {
                await _consumer.DeleteDayTimeSlot(dayId, timeSlotId);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("DayTimeSlot")))
                {
                    return NotFound();
                }
                throw e;
            }
        }
    }
}
