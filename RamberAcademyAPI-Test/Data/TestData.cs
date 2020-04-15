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
    }
}
