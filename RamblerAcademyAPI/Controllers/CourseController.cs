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
    public class CourseController : Controller
    {
        private readonly CourseConsumer _consumer;
        
        public CourseController(CourseConsumer consumer)
        {
            _consumer = consumer;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult>Get()
        {
            List<Course> courses = await _consumer.GetAllCoursesAsync();
            return Ok(courses);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            Course course = await _consumer.GetCourseByIdAsync(id);
            if(course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult> Post(Course course)
        {
            var newCourse = await _consumer.CreateCourseAsync(course);
            return Ok(newCourse);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Course course)
        {
            try
            {
                Course newCourse = await _consumer.UpdateCourseAsync(id, course);
                return Ok(newCourse);
            }catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Course")))
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
                await _consumer.DeleteCourseAsync(id);
                return Ok();
            }catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Course")))
                {
                    return NotFound();
                }
                throw e;
            }
        }
    }
}
