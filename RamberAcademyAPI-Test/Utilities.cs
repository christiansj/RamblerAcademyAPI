using RamblerAcademyAPI.Data;
using System;
using System.Collections.Generic;
using System.Text;
using RamblerAcademyAPI.Models;
using Newtonsoft.Json.Linq;
using Xunit.Abstractions;
using Xunit;
using RamberAcademyAPI_Test.Data;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace RamberAcademyAPI_Test
{
    public class Utilities
    {
        public async static Task IntializeDbForTests(RamblerAcademyContext db)
        {
            db.Buildings.RemoveRange(db.Buildings);
            db.Buildings.AddRange(TestData.Buildings());

            db.Classrooms.RemoveRange(db.Classrooms);
            db.Classrooms.AddRange(TestData.Classrooms());

            db.Days.RemoveRange(db.Days);
            db.Days.AddRange(TestData.Days());

            db.Seasons.RemoveRange(db.Seasons);
            db.Seasons.AddRange(TestData.Seasons());

            db.Semesters.RemoveRange(db.Semesters);
            db.Semesters.AddRange(TestData.Semesters());


            db.Subjects.RemoveRange(db.Subjects);
            db.Subjects.AddRange(TestData.Subjects());

            db.Courses.RemoveRange(db.Courses);
            db.Courses.AddRange(TestData.Courses());

            db.Roles.RemoveRange(db.Roles);
            db.Roles.AddRange(TestData.Roles());

            db.Users.RemoveRange(db.Users);
            db.Users.AddRange(TestData.Users());

           

            await db.SaveChangesAsync();
        }

        public async static Task AddMoreData(RamblerAcademyContext db)
        {

            db.CourseSections.RemoveRange(db.CourseSections);
            db.CourseSections.AddRange(TestData.CourseSections());

            db.Enrollments.RemoveRange(db.Enrollments);
            db.Enrollments.AddRange(TestData.Enrollments());
            await db.SaveChangesAsync();
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
