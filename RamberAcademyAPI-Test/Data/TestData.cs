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

        public static List<Day> Days()
        {
            return new List<Day>
            {
                new Day(1, "Test Day 1"),
                new Day(2, "Test Day 2"),
                new Day(3, "Test Day 3")
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

        public static List<Classroom> Classrooms()
        {
            return new List<Classroom>
            {
                new Classroom(1, 1, 2, 11, 50, 1),
                new Classroom(2, 1, 3, 22, 50, 1),
                new Classroom(3, 1, 4, 32, 30, 1),

                new Classroom(4, 1, 1, 1, 200, 2),
                new Classroom(5, 1, 2, 24, 200, 2),
                new Classroom(6, 1, 3, 34, 100, 2),
            };
        }

        public static List<Role> Roles()
        {
            return new List<Role>
            {
                new Role(1, "Test Role 1"),
                new Role(2, "Test Role 2")
            };
        }

        public static List<User> Users()
        {
            return new List<User>
            {
                new User(1, "ajf134", "Test", "User", "testUser@example.com", "password", 1),
                new User(2, "exc144", "Rest", "Wser", "testUser2@example.com", "password", 1),
                new User(3, "foe344", "Test", "User", "testUser3@example.com", "password", 1),
                new User(4, "fje894", "Test f", "User z", "testUser4@example.com", "password", 1),
            };
        }

        public static List<CourseSection> CourseSections()
        {
            return new List<CourseSection>
            {
                new CourseSection(57894, 1, 2, 1, 3),
                new CourseSection(54758, 1, 3, 1, 1),
                new CourseSection(47593, 1, 1, 1, 2)
            };
        }

        public static List<Enrollment> Enrollments()
        {
            return new List<Enrollment>
            {
                new Enrollment(57894, 1),
                new Enrollment(47593, 1),

                new Enrollment(54758, 2)
            };
        }

        public static List<TimeSlot> TimeSlots()
        {
            return new List<TimeSlot>
            {
                new TimeSlot(1, new TimeSpan(9, 0, 0), new TimeSpan(9, 50, 0)),
                new TimeSlot(2, new TimeSpan(10, 0, 0), new TimeSpan(10, 50, 0)),
                new TimeSlot(3, new TimeSpan(11, 0, 0), new TimeSpan(11, 50, 0))
            };
        }

        public static List<DayTimeSlot> DayTimeSlots()
        {
            return new List<DayTimeSlot>
            {
                new DayTimeSlot(1,1),
                
                new DayTimeSlot(2,3),

                new DayTimeSlot(3, 2)
            };
        }

        public static List<CourseSectionDayTimeSlot> CourseSectionDayTimeSlots()
        {
            return new List<CourseSectionDayTimeSlot>
            {
                new CourseSectionDayTimeSlot(57894, 1, 1),
                new CourseSectionDayTimeSlot(47593, 3, 2),
                new CourseSectionDayTimeSlot(54758, 2, 3)
            };
        }
    }
}
