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
    public class SubjectController : Controller, IOneIdApiController<Subject>
    {
        private readonly SubjectConsumer _consumer;

        public SubjectController(SubjectConsumer consumer)
        {
            _consumer = consumer;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            List<Subject> subjects = await _consumer.GetAllSubjectsAsync();
            return Ok(subjects);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Subject subject = await _consumer.GetSubjectByIdAsync(id);
            if(subject == null)
            {
                return NotFound();
            }
            return Ok(subject);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult> Post(Subject subject)
        {
            Subject newSubject = await _consumer.CreateSubjectAsync(subject);
            return Ok(newSubject);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Subject subject)
        {
            try
            {
                Subject newSubject = await _consumer.UpdateSubjectAsync(id, subject);
                return Ok(newSubject);
            } catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Subject")))
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
                await _consumer.DeleteSubjectAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Subject")))
                {
                    return NotFound();
                }
                throw e;
            }
        }
    }
}
