using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.Models
{
    public class Classroom
    {
        public int Id { get; set; }
        public int Floor { get; set; }
        public int HallwayNumber { get; set; }
        public int RoomNumber { get; set; }

        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
