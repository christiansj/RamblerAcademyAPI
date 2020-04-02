using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Models
{
    public class Season
    {
        public int Id { get; set; }


        public String Name { get; set; }

        public List<Semester> Semesters { get; set; }
    }
}
