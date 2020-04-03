using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RamblerAcademyAPI.Models
{
    public class Semester
    {
        public Semester(int id, int year, DateTime startDate, DateTime endDate, int seasonId)
        {
            Id = id;
            Year = year;
            StartDate = startDate;
            EndDate = endDate;
            SeasonId = seasonId;
        }

        [Key]
        public int Id { get; set; }
        [ForeignKey("Season")]
        public int SeasonId { get; set; }
        public Season Season { get; set; }
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<CourseSection> CourseSections { get; set; }
    }
}
