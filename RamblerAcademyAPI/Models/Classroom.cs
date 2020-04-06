using System.ComponentModel.DataAnnotations.Schema;

namespace RamblerAcademyAPI.Models
{
    public class Classroom
    {
        public Classroom()
        {

        }

        public Classroom(int id, int floor, int hallwayNumber, int roomNumber, int buildingId)
        {
            Id = id;
            Floor = floor;
            HallwayNumber = hallwayNumber;
            RoomNumber = roomNumber;
            BuildingId = buildingId;
        }

        public int Id { get; set; }
        public int Floor { get; set; }
        public int HallwayNumber { get; set; }
        public int RoomNumber { get; set; }

        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
