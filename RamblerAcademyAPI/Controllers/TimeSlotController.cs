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
    public class TimeSlotController : Controller, IOneIdApiController<TimeSlot>
    {
        private readonly TimeSlotConsumer _consumer;

        public TimeSlotController(TimeSlotConsumer consumer)
        {
            _consumer = consumer;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IEnumerable<TimeSlot> timeSlots = await _consumer.GetAllTimeSlotsAsync();
            return Ok(timeSlots);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            TimeSlot timeSlot = await _consumer.GetTimeSlotByIdAsync(id);
            if(timeSlot == null)
            {
                return NotFound();
            }
            return Ok(timeSlot);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult> Post(TimeSlot timeSlot)
        {
            TimeSlot newTimeSlot = await _consumer.CreateTimeSlotAsync(timeSlot);
            return Ok(newTimeSlot);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, TimeSlot timeSlot)
        {
            try
            {
                TimeSlot newTimeSlot = await _consumer.UpdateTimeSlotAsync(id, timeSlot);
                return Ok(newTimeSlot);
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("TimeSlot")))
                {
                    return NotFound();
                }
                throw e;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _consumer.DeleteTimeSlotAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("TimeSlot")))
                {
                    return NotFound();
                }
                throw e;
            }
        }
    }
}
