using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RamberAcademyAPI_Test.Data
{
    public class TestData
    {
        public static List<Building> Buildings()
        {
            return new List<Building>
            {
                new Building(1, "Test Building 1"),
                new Building(2, "Test Building 2")
            };
        }

        public static List<Subject> Subjects()
        {
            return new List<Subject>
            {
                new Subject(1, "Test Math", "MAT"),
                new Subject(2, "Test English", "ENG"),
                new Subject(3, "Test History", "HIS")
            };
        }

        public static List<Course> Courses()
        {
            return new List<Course>
            {
                new Course(1, 100, "Test Math Course 1", 1),
                new Course(2, 200, "Test Math Course 2", 1),

                new Course(3, 100, "Test English Course 1", 2),
                new Course(4, 200, "Test English Course 2", 2)
            };
        }

        public static List<Season> Seasons()
        {
            return new List<Season>
            {
                new Season(1, "Test Season 1"),
                new Season(2, "Test Season 2")
            };
        }

        public static List<Semester> Semesters()
        {
            return new List<Semester>
            {
                new Semester(1, 2018, new DateTime(2018, 1, 8), new DateTime(2018, 5, 11), 1),
                new Semester(2, 2018, new DateTime(2018, 5, 16), new DateTime(2018, 8, 19), 2),
                new Semester(3, 2018, new DateTime(2018, 8, 26), new DateTime(2018, 12, 18), 3)
            };
        }
    }
}
