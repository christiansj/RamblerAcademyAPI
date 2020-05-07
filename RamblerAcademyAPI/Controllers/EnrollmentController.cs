using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RamblerAcademyAPI.GraphQL.GraphQLConsumers;
using RamblerAcademyAPI.GraphQL.GraphQLUserErrors;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.Controllers
{
    [Route("api/[controller]")]
    public class EnrollmentController : Controller
    {
        private readonly EnrollmentConsumer _consumer;

        public EnrollmentController(EnrollmentConsumer consumer)
        {
            _consumer = consumer;
        }

        [HttpGet("student/{studentId}")]
        public async Task<ActionResult> GetEnrollmentsPerStudent(long studentId)
        {
            IEnumerable<Enrollment> enrollments = await _consumer.GetEnrollmentsPerStudentAsync(studentId);
            return Ok(enrollments);
        }

        [HttpGet("courseSection/{crn}")]
        public async Task<ActionResult> GetEnrollmentsPerCourseSection(int crn)
        {
            IEnumerable<Enrollment> enrollments = await _consumer.GetEnrollmentsPerCourseSection(crn);
            return Ok(enrollments);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Enrollment enrollment)
        {
            Enrollment newEnrollment = await _consumer.CreateEnrollmentAsync(enrollment);
            return Ok(newEnrollment);
        }

        [HttpDelete("student/{studentId}/courseSection/{crn}")]
        public async Task<ActionResult> Delete(long studentId, int crn)
        {
            try
            {
                await _consumer.DeleteEnrollmentAsync(studentId, crn);
                return Ok();
            }catch(Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("Enrollment")))
                {
                    return NotFound();
                }
                throw e;
            }
        }
    }
}
