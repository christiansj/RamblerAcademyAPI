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
    public class RoleController : Controller, IOneIdApiController<Role>
    {
        private readonly RoleConsumer _consumer;

        public RoleController(RoleConsumer consumer)
        {
            _consumer = consumer;
        }
        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IEnumerable<Role> roles = await _consumer.GetAllRolesAsync();

            return Ok(roles);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Role role = await _consumer.GetRoleByIdAsync(id);
            if(role == null)
            {
                return NotFound();
            }
            return Ok(role);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult> Post(Role role)
        {
            Role newRole = await _consumer.CreateRoleAsync(role);
            return Ok(newRole);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Role role)
        {
            try
            {
                Role newRole = await _consumer.UpdateRoleAsync(id, role);
                return Ok(newRole);
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Role")))
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
                await _consumer.DeleteRoleAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Role")))
                {
                    return NotFound();
                }
                throw e;
            }
        }
    }
}
