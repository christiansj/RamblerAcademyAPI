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
    public class UserController : Controller, IOneIdApiController<User>
    {
        private readonly UserConsumer _consumer;

        public UserController(UserConsumer consumer)
        {
            _consumer = consumer;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IEnumerable<User> users = await _consumer.GetAllUsersAsync();
            return Ok(users);
        }


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(long id)
        {
            User user = await _consumer.GetUserByIdAsync(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult> Post(User user)
        {
            User newUser = await _consumer.CreateUserAsync(user);
            return Ok(newUser);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(long id, User user)
        {
            try
            {
                User newUser = await _consumer.UpdateUserAsync(id, user);
                return Ok(newUser);
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("User")))
                {
                    return NotFound();
                }
                throw e;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                await _consumer.DeleteUserAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("User")))
                {
                    return NotFound();
                }
                throw e;
            }
        }

        public Task<ActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> Put(int id, User t)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
