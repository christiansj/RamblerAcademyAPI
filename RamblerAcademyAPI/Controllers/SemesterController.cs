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
    public class SemesterController : Controller, IApiController<Semester>
    {
        private readonly SemesterConsumer _consumer;

        public SemesterController(SemesterConsumer consumer)
        {
            _consumer = consumer;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IEnumerable<Semester> semesters = await _consumer.GetAllSemestersAsync();
            return Ok(semesters);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Semester semester = await _consumer.GetSemesterByIdAsync(id);
            if(semester == null)
            {
                return NotFound();
            }
            return Ok(semester);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult> Post(Semester semester)
        {
            Semester newSemester = await _consumer.CreateSemesterAsync(semester);
            return Ok(newSemester);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Semester semester)
        {
            try
            {
                Semester newSemester = await _consumer.UpdateSemesterAsync(id, semester);
                return Ok(newSemester);
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Semester")))
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
                await _consumer.DeleteSemesterAsync(id);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Semester")))
                {
                    return NotFound();
                }
                throw e;
            }
        }
    }
}
