using System;

namespace PremisesTest.Models
{
    public class Room
    {
        public Guid roomId { get; set; }
        public string  roomName{ get; set; }
        public Guid? buildingId { get; set; }
        public Building Buildings { get; set; }
    }
}
