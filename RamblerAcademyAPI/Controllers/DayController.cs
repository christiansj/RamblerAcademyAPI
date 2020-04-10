using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers;
using RamblerAcademyAPI.GraphQL.GraphQLUserErrors;
using RamblerAcademyAPI.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RamblerAcademyAPI.Controllers
{
    [Route("api/[controller]")]
    public class DayController : Controller
    {
        private readonly DayConsumer _consumer;
        public DayController(DayConsumer consumer)
        {
            _consumer = consumer;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IEnumerable<Day> days = await _consumer.GetAllDaysAsync();
            return Ok(days);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Day day = await _consumer.GetDayByIdAsync(id);
            if(day == null)
            {
                return NotFound();
            }
            return Ok(day);
        }
    }
}
