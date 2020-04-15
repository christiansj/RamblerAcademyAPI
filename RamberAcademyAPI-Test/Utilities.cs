﻿using RamblerAcademyAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RamblerAcademyAPI.Models;
using Newtonsoft.Json.Linq;
using Xunit.Abstractions;
using Xunit;
using RamberAcademyAPI_Test.Data;
using Newtonsoft.Json;

namespace RamberAcademyAPI_Test
{
    public class Utilities
    {
        public static void IntializeDbForTests(RamblerAcademyContext db)
        {
            db.Buildings.RemoveRange(db.Buildings);
            db.Buildings.AddRange(TestData.Buildings());

            db.Seasons.RemoveRange(db.Seasons);
            db.Seasons.AddRange(TestData.Seasons());

            db.Semesters.RemoveRange(db.Semesters);
            db.Semesters.AddRange(TestData.Semesters());

            db.Subjects.RemoveRange(db.Subjects);
            db.Subjects.AddRange(TestData.Subjects());

            db.Courses.RemoveRange(db.Courses);
            db.Courses.AddRange(TestData.Courses());
            db.SaveChanges();
        }

        public static string ParseData(string contentString, string requestName)
        {
            var errors = JObject.Parse(contentString)["errors"];
            if (errors != null)
            {
                string error = errors[0]["message"].ToString();
                Assert.True(false, error);
            }
            return JObject.Parse(contentString)["data"][requestName].ToString();
        }

       
    }
}
