using System;
using System.Collections.Generic;

namespace RamblerAcademyAPI.Models
{
    public class Season
    {
        public Season(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Semester> Semesters { get; set; }
    }
}
