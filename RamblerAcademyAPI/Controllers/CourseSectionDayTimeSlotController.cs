﻿using System;
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
    public class CourseSectionDayTimeSlotController : Controller
    {
        private readonly CourseSectionDayTimeSlotConsumer _consumer;

        public CourseSectionDayTimeSlotController(CourseSectionDayTimeSlotConsumer consumer)
        {
            _consumer = consumer;
        }

        // GET: api/<controller>
        [HttpGet("crn/{crn}")]
        public async Task<ActionResult> GetPerCourseSection(int crn)
        {
            IEnumerable<CourseSectionDayTimeSlot> csdts = await _consumer.GetAllPerCourseSectionAsync(crn);

            return Ok(csdts);
        }

        // GET api/<controller>/5
        [HttpGet("dayId/{dayId}")]
        public async Task<ActionResult> GetPerDay(int dayId)
        {
            IEnumerable<CourseSectionDayTimeSlot> csdts = await _consumer.GetAllPerDayAsync(dayId);

            return Ok(csdts);
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult> Post(CourseSectionDayTimeSlot csdt)
        {
            CourseSectionDayTimeSlot newCSDT = await _consumer.CreateAsync(csdt);
            return Ok(newCSDT);
        }

       

        // DELETE api/<controller>/5
        [HttpDelete("crn/{crn}/dayId/{dayId}/timeSlotId/{timeSlotId}")]
        public async Task<ActionResult> Delete(int crn, int dayId, int timeSlotId)
        {
            try
            {
                await _consumer.DeleteAsync(crn, dayId, timeSlotId);
                return Ok();
            }
            catch (Exception e)
            {
                if (e.Message.Contains(GraphQLUserError.NotFoundString("CourseSectionDayTimeSlot")))
                {
                    return NotFound();
                }
                throw e;
            }
        }
    }
}
