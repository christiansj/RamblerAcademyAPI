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
    public class SeasonController : Controller, IApiController<Season>
    {
        private readonly SeasonConsumer _consumer;

        public SeasonController(SeasonConsumer consumer)
        {
            _consumer = consumer;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IEnumerable<Season> seasons = await _consumer.GetAllSeasonsAsync();
            return Ok(seasons);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Season season = await _consumer.GetSeasonByIdAsync(id);
            if(season == null)
            {
                return NotFound();
            }
            return Ok(season);

        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult> Post(Season season)
        {
            Season newSeason = await _consumer.CreateSeasonAsync(season);
            return Ok(newSeason);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Season season)
        {
            try
            {
                Season newSeason = await _consumer.UpdateSeasonAsync(id, season);
                return Ok(newSeason);
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Season")))
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
                 await _consumer.DeleteSeasonAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Season")))
                {
                    return NotFound();
                }
                throw e;
            }
        }
    }
}
