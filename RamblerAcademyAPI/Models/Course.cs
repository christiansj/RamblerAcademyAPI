using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Models
{
    public class Course
    {
        [Key]
        public String Id { get; set; }

        public String Name { get; set; }

        public List<CourseSemester> CourseSemsters { get; set; }
    }
}
