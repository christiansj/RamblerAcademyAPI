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
    public class CourseSectionController : Controller, IOneIdApiController<CourseSection>
    {
        private readonly CourseSectionConsumer _consumer;

        public CourseSectionController(CourseSectionConsumer consumer)
        {
            _consumer = consumer;
        }

        // GET api/<controller>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            IEnumerable<CourseSection> courseSections = await _consumer.GetAllCourseSectionsAsync();
            return Ok(courseSections);
        }

        // GET api/<controller>/semester/{semesterId}/subject/{subjectId}
        [HttpGet("semester/{semesterId}/subject/{subjectId}")]
        public async Task<ActionResult> GetPerSemesterAndSubject(int semesterId, int subjectId)
        {
            IEnumerable<CourseSection> courseSections = await _consumer.GetAllPerSemesterAndSubject(semesterId, subjectId);
            return Ok(courseSections);
        }

        // GET api/<controller>/5
        [HttpGet("{crn}")]
        public async Task<ActionResult> Get(int crn)
        {
            CourseSection courseSection = await _consumer.GetCourseSectionByIdAsync(crn);
            if(courseSection == null)
            {
                return NotFound();
            }
            return Ok(courseSection);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult> Post(CourseSection courseSection)
        {
            CourseSection newCourseSection = await _consumer.CreateCourseSectionAsync(courseSection);
            return Ok(newCourseSection);
        }

        // PUT api/<controller>/5
        [HttpPut("{crn}")]
        public async Task<ActionResult> Put(int crn, CourseSection courseSection)
        {
            try
            {
                CourseSection newCourseSection = await _consumer.UpdateCourseSectionAsync(crn, courseSection);
                if(newCourseSection == null)
                {
                    return NotFound();
                }
                return Ok(courseSection);
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("CourseSection")))
                {
                    return NotFound();
                }
                throw e;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{crn}")]
        public async Task<ActionResult> Delete(int crn)
        {
            try
            {
                await _consumer.DeleteCourseSectionAsync(crn);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("CourseSection")))
                {
                    return NotFound();
                }
                throw e;
            }
        }
    }
}
