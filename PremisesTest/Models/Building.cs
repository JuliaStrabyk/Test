using System;
using System.Collections.Generic;

namespace PremisesTest.Models
{
     public class Building
        {
        public Guid buildingId { get; set; }
        public string nameBuilding { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public Building()
        {
            Rooms = new List<Room>();
        }
    }
}
