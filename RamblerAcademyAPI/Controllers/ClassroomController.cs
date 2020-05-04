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
    public class ClassroomController : Controller, IOneIdApiController<Classroom>
    {
        private readonly ClassroomConsumer _consumer;

        public ClassroomController(ClassroomConsumer consumer)
        {
            _consumer = consumer;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IEnumerable<Classroom> classrooms = await _consumer.GetAllClassroomAsync();
            return Ok(classrooms);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Classroom classroom = await _consumer.GetClassroomByIdAsync(id);
            if(classroom == null)
            {
                return NotFound();
            }
            return Ok(classroom);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult> Post(Classroom classroom)
        {
            Classroom newClassroom = await _consumer.CreateClassroomAsync(classroom);
            return Ok(newClassroom);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Classroom classroom)
        {
            try
            {
                Classroom newClassroom = await _consumer.UpdateClassroomAsync(id, classroom);
                return Ok(newClassroom);

            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Classroom")))
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
                await _consumer.DeleteClassroomAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Classroom")))
                {
                    return NotFound();
                }
                throw e;
            }
        }
    }
}
