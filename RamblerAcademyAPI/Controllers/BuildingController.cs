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
    [ApiController]
    [Route("api/[controller]")]
    public class BuildingController : Controller
    {
        private readonly BuildingConsumer _consumer;
        
        public BuildingController(BuildingConsumer consumer)
        {
            _consumer = consumer;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get()
        { 
            List<Building> buildings = await _consumer.GetAllBuildings();
            return Ok(buildings);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Building building = await _consumer.GetBuildingById(id);
            if(building == null)
            {
                return NotFound();
            }
            return Ok(building);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Building>> Post(Building building)
        {
            
            Building newBuilding = await _consumer.CreateBuilding(building);
            return newBuilding;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Building building)
        {
            try
            {
                Building newBuilding = await _consumer.UpdateBuilding(id, building);
                return Ok(newBuilding);
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Building")))
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
                await _consumer.DeleteBuilding(id);
                return Ok();
            }
            catch(Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Building")))
                {
                    return NotFound();
                }
                throw e;
            }
        }
    }
}
