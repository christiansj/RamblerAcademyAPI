using System.ComponentModel.DataAnnotations.Schema;

namespace RamblerAcademyAPI.Models
{
    public class Classroom
    {
        public Classroom()
        {

        }

        public Classroom(int id, int floor, int hallwayNumber, int roomNumber, int maxCapacity, int buildingId)
        {
            Id = id;
            Floor = floor;
            HallwayNumber = hallwayNumber;
            RoomNumber = roomNumber;
            MaxCapacity = maxCapacity;
            BuildingId = buildingId;
        }

        public int Id { get; set; }
        public int Floor { get; set; }
        public int HallwayNumber { get; set; }
        public int RoomNumber { get; set; }
        public int MaxCapacity { get; set; }

        [ForeignKey("Building")]
        public int BuildingId { get; set; }
        public Building Building { get; set; }
    }
}
